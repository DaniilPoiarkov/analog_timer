using AnalogTimer.Contracts;
using AnalogTimer.Helpers;
using AnalogTimer.Models;
using AnalogTimer.Models.Enums;
using NLog;
using System.Diagnostics;
using TimerEngine.Models.TimerEventArgs;

namespace AnalogTimer.Implementations;

public class AnalogTimer : IAnalogTimer
{
    private readonly TimerState _state;

    private readonly Logger _logger = LogManager.GetCurrentClassLogger();


    public event TimerTick? Tick;

    public event TimerUpdated? Updated;

    public event TimerUpdated? TimerStarted;

    public delegate void TimerTick(TimerState state);

    public delegate void TimerUpdated(TimerEventArgs state);


    public bool IsRunning { get; private set; }

    public TimerType Type { get; private set; }


    private int TicksPerSecond { get; set; }

    private Func<Task>? Counter { get; set; }

    private Task? Execution { get; set; }

    private Action<int> StateCallback { get; set; }


    private static readonly TimeSpan _baseDelay = TimeSpan.FromMilliseconds(95);

    public AnalogTimer(TimerState state)
    {
        _state = state;

        IsRunning = false;
        TicksPerSecond = 1;
        Type = TimerType.Stopwatch;

        StateCallback = _state.AddMilliseconds;
    }

    public AnalogTimer()
        : this(new()) { }

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

        var args = new TimerEventArgs()
        {
            State = _state,
        };

        Updated?.Invoke(args);
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

        TimerStarted?.Invoke(new TimerEventArgs()
        {
            State = _state,
            TimerType = Type,
        });

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
        Tick?.Invoke(_state);
        
        while (IsRunning)
        {
            try
            {
                await Task.Delay(_baseDelay);

                StateCallback.Invoke(TicksPerSecond);
                
                Tick?.Invoke(_state);

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

        if(_state.IsZero)
            MillisecondDisplayHelper.DisplayZero();

        IsRunning = false;
        await Execution;
        Counter = null;
    }
}
