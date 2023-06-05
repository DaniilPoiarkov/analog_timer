using AnalogTimer.Contracts;
using AnalogTimer.Helpers;
using AnalogTimer.Models;
using NLog;
using TimerEngine.Models.Enums;
using TimerEngine.Models.TimerEventArgs;
using static TimerEngine.Contracts.ITimerEvents;

namespace AnalogTimer.Implementations;

public class AnalogTimer : IAnalogTimer
{
    private readonly TimerState _state;

    private readonly Logger _logger = LogManager.GetCurrentClassLogger();

    private delegate Task CounterExecutor();


    public event TimerTick? Tick;

    public event TimerUpdated? Updated;

    public event TimerUpdated? TimerStarted;

    public event TimerUpdated? TimerCut;

    public event TimerUpdated? Stopeed;

    private TimerEventArgs TimerEventArgs => new()
    {
        State = GetSnapshot(),
        TimerType = Type,
    };


    public bool IsRunning { get; private set; }

    public TimerType Type { get; private set; }


    public int TicksPerSecond { get; private set; }

    private /*Func<Task>?*/ CounterExecutor? Counter { get; set; }

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

    public void Cut()
    {
        TimerCut?.Invoke(TimerEventArgs);
    }

    public void SetTimerType(TimerType type)
    {
        UpdateState(timer => timer.Type = type);
    }

    public void ChangeSpeed(int ticksPerSecond)
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

        Updated?.Invoke(TimerEventArgs);
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

        TimerStarted?.Invoke(TimerEventArgs);

        StateCallback = Type switch
        {
            TimerType.Timer => _state.SubtractMilliseconds,
            TimerType.Stopwatch => _state.AddMilliseconds,
            _ => throw new ArgumentOutOfRangeException(),
        };

        MillisecondDisplayHelper.BackgroundDisplay();

        IsRunning = true;
        Counter = new CounterExecutor(StartTimerTemplate);
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
                    IsRunning = false;

                    MillisecondDisplayHelper.StopDisplay();
                    MillisecondDisplayHelper.DisplayZero();

                    Stopeed?.Invoke(new() { IsStopped = true });
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

        if (_state.IsZero)
        {
            MillisecondDisplayHelper.DisplayZero();
        }

        IsRunning = false;
        await Execution;
        Counter = null;
        Stopeed?.Invoke(new() { IsStopped = true });
    }
}
