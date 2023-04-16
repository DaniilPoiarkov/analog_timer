using AnalogTimer.Contracts;
using AnalogTimer.Models;

namespace AnalogTimer.Implementations;

public class AnalogTimer : IAnalogTimer
{
    private readonly TimerState _state;

    private readonly DisplayService _displayService;

    public bool IsRunning { get; private set; }

    private int TicksPerSecond { get; set; }

    private Func<Task>? Counter { get; set; }

    private Task? Execution { get; set; }

    public AnalogTimer(TimerState state, ITimerTemplate template)
    {
        _state = state;
        IsRunning = false;
        TicksPerSecond = 1;
        _displayService = new(template);
    }

    public AnalogTimer()
        : this(new(), new DefaultPattern()) { }

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

    public async Task ResetState()
    {
        if (IsRunning)
        {
            await Stop();
        }

        _state.Reset();
        _displayService.Display(_state);
    }

    private void UpdateState(Action<TimerState> stateUpdateAction)
    {
        if (IsRunning)
        {
            throw new Exception("Cannot update timer when it is running");
        }

        stateUpdateAction?.Invoke(_state);
        _displayService.Display(_state);
    }

    public void Start()
    {
        if (IsRunning)
        {
            throw new Exception("Timer is already running");
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
            await _state.Wait(TicksPerSecond);
            _displayService.Display(_state);

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
            throw new Exception("Timer is not running");
        }

        IsRunning = false;
        await Execution;
        Counter = null;
    }
}
