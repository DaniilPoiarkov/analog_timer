using AnalogTimer.Contracts;
using AnalogTimer.Models;
using NLog;

namespace AnalogTimer.Implementations;

public class AnalogTimer : IAnalogTimer
{
    private readonly TimerState _state;

    private readonly IDisplayService _displayService;

    public bool IsRunning { get; private set; }

    private int TicksPerSecond { get; set; }

    private Func<Task>? Counter { get; set; }

    private Task? Execution { get; set; }

    public AnalogTimer(TimerState state, ITimerTemplate template)
    {
        _state = state;
        IsRunning = false;
        TicksPerSecond = 1;
        _displayService = new DisplayService(template);
    }

    public AnalogTimer()
        : this(new(), new DefaultTemplate()) { }

    public void ChangeTicksPerSecond(int ticksPerSecond)
    {
        TicksPerSecond = ticksPerSecond;
    }

    public void AddSeconds(int seconds)
    {
        UpdateState(state => state.AddSeconds(seconds));
    }

    public void AddMinutes(int minutes)
    {
        UpdateState(state => state.AddMinutes(minutes));
    }

    public void AddHours(int hours)
    {
        UpdateState(state => state.AddHours(hours));
    }

    public void ResetState()
    {
        UpdateState(state => state.Reset());
    }

    private void UpdateState(Action<TimerState> stateUpdateAction)
    {
        if (IsRunning)
        {
            throw new InvalidOperationException("Cannot update timer when it is running");
        }

        stateUpdateAction?.Invoke(_state);
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
                await _state.Wait(TicksPerSecond);
                _displayService.Display(_state);
            }
            catch (Exception ex)
            {
                var logger = LogManager.GetCurrentClassLogger();
                logger.Error(ex, "Handled when wait or display");
            }

            if (_state.IsZero)
            {
                await Stop();
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
