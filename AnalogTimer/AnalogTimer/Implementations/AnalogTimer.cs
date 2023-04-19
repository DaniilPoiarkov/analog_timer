using AnalogTimer.Contracts;
using AnalogTimer.Models;
using AnalogTimer.Models.Enums;
using NLog;

namespace AnalogTimer.Implementations;

public class AnalogTimer : IAnalogTimer
{
    private readonly TimerState _state;

    private readonly IDisplayService _displayService;


    public bool IsRunning { get; private set; }

    public TimerType Type { get; private set; }


    private int TicksPerSecond { get; set; }

    private Func<Task>? Counter { get; set; }

    private Task? Execution { get; set; }


    private const int _baseDelay = 1000;

    private const int _oneSecond = 1;

    public AnalogTimer(TimerState state, IDisplayService displayService)
    {
        _state = state;
        _displayService = displayService;

        IsRunning = false;
        TicksPerSecond = 1;
        Type = TimerType.Timer;
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
        _displayService.Display(_state);
    }

    public void Start()
    {
        if (IsRunning)
        {
            throw new InvalidOperationException("Timer is already running");
        }

        if (_state.IsZero)
        {
            throw new InvalidOperationException("Timer state consist of zeros. Set time before starting timer");
        }

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
                await Task.Delay(_baseDelay / TicksPerSecond);
                
                if (Type == TimerType.Timer)
                {
                    _state.SubtractSeconds(_oneSecond);
                }
                else
                {
                    _state.AddSeconds(_oneSecond);
                }

                _displayService.Display(_state);

                if (_state.IsZero)
                {
                    await Stop();
                }
            }
            catch (Exception ex)
            {
                var logger = LogManager.GetCurrentClassLogger();
                logger.Error(ex, "Handled when wait, display or stop");
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
