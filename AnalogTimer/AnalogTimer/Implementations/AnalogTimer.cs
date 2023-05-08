using AnalogTimer.Contracts;
using AnalogTimer.Helpers;
using AnalogTimer.Models;
using AnalogTimer.Models.Enums;
using NLog;
using System.Diagnostics;

namespace AnalogTimer.Implementations;

public class AnalogTimer : IAnalogTimer
{
    private readonly TimerState _state;

    private readonly IDisplayService _displayService;

    private readonly Logger _logger = LogManager.GetCurrentClassLogger();


    public bool IsRunning { get; private set; }

    public TimerType Type { get; private set; }


    private int TicksPerSecond { get; set; }

    private Func<Task>? Counter { get; set; }

    private Task? Execution { get; set; }

    private Action<int> StateCallback { get; set; }


    private static readonly TimeSpan _baseDelay = TimeSpan.FromMilliseconds(90);

    public AnalogTimer(TimerState state, IDisplayService displayService)
    {
        _state = state;
        _displayService = displayService;

        IsRunning = false;
        TicksPerSecond = 1;
        Type = TimerType.Timer;

        StateCallback = _state.SubtractMilliseconds;
        _displayService.SetMode(DisplayMode.Down);
    }

    public AnalogTimer()
        : this(new(), new DisplayService(new DefaultTemplate())) { }

    public TimerState GetSnapshot()
    {
        return new TimerState(_state.Hours, _state.Minutes, _state.Seconds, _state.Milliseconds);
    }

    public void SetTimerType(TimerType type)
    {
        UpdateState(timer => timer.Type = type);
    }

    public void ChangeTicksPerSecond(int ticksPerSecond)
    {
        UpdateState(timer => timer.TicksPerSecond = ticksPerSecond);
    }

    public void AddSeconds(int seconds)
    {
        UpdateState(timer => timer._state.AddSeconds(seconds));
    }

    public void AddMinutes(int minutes)
    {
        UpdateState(timer => timer._state.AddMinutes(minutes));
    }

    public void AddHours(int hours)
    {
        UpdateState(timer => timer._state.AddHours(hours));
    }

    public void ResetState()
    {
        UpdateState(timer => timer._state.Reset());
    }

    private void UpdateState(Action<AnalogTimer> stateUpdateAction)
    {
        if (IsRunning)
        {
            throw new InvalidOperationException("Cannot update timer when it is running");
        }

        stateUpdateAction?.Invoke(this);

        _displayService.SetMode(DisplayMode.Full);
        _displayService.Display(_state);
    }

    public void Start()
    {
        if (IsRunning)
        {
            throw new InvalidOperationException("Timer is already running");
        }

        if (_state.IsZero && Type == TimerType.Timer)
        {
            throw new InvalidOperationException("Timer state consist of zeros. Set time before starting timer");
        }

        var mode = Type switch
        {
            TimerType.Timer => DisplayMode.Down,
            TimerType.Stopwatch => DisplayMode.Up,
            _ => throw new ArgumentOutOfRangeException(),
        };

        _displayService.SetMode(mode);

        StateCallback = Type switch
        {
            TimerType.Timer => _state.SubtractMilliseconds,
            TimerType.Stopwatch => _state.AddMilliseconds,
            _ => throw new ArgumentOutOfRangeException(),
        };

        MillisecondDisplayHelper.BackgroundDisplay();

        IsRunning = true;
        Counter = StartTimerTemplate;
        Execution = Counter.Invoke();
    }

    private async Task StartTimerTemplate()
    {
        _displayService.Display(_state);
        
        while (IsRunning)
        {
            try
            {
                await Task.Delay(_baseDelay);

                StateCallback.Invoke(TicksPerSecond);
                
                _displayService.Display(_state);

                if (_state.IsZero)
                {
                    await Stop();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Handled is {ex.Source}");
            }
        }
    }

    public async Task Stop()
    {
        if (!IsRunning || Execution is null)
        {
            throw new InvalidOperationException("Timer is not running");
        }

        MillisecondDisplayHelper.StopDisplay();

        IsRunning = false;
        await Execution;
        Counter = null;
    }
}
