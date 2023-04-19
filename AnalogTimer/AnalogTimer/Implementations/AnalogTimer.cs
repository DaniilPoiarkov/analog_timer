using AnalogTimer.Contracts;
using AnalogTimer.Models;
using AnalogTimer.Models.Enums;
using NLog;

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


    private const int _baseDelay = 100;

    public AnalogTimer(TimerState state, IDisplayService displayService)
    {
        _state = state;
        _displayService = displayService;

        IsRunning = false;
        TicksPerSecond = 1;
        Type = TimerType.Timer;
        _displayService.SetMode(DisplayMode.Down);
    }

    public AnalogTimer()
        : this(new(), new DisplayService(new DefaultTemplate())) { }

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
                
                if (Type == TimerType.Timer)
                {
                    _state.SubtractMilliseconds(TicksPerSecond);
                }
                else
                {
                    _state.AddMilliseconds(TicksPerSecond);
                }

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

        IsRunning = false;
        await Execution;
        Counter = null;
    }
}
