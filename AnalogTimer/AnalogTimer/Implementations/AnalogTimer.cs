using AnalogTimer.Contracts;
using AnalogTimer.Models;

namespace AnalogTimer.Implementations;

public class AnalogTimer : IAnalogTimer
{
    private readonly TimerState _state;

    public bool IsRunning { get; private set; }

    private int TicksPerSecond { get; set; }

    private Func<Task>? Counter { get; set; }

    public AnalogTimer(TimerState state)
    {
        _state = state;
        IsRunning = false;
        TicksPerSecond = 1;
    }

    public AnalogTimer()
        : this(new()) { }

    public void AddSeconds(int seconds)
    {
        _state.AddSeconds(seconds);
    }

    public void Start()
    {
        if(IsRunning)
        {
            return;
        }

        IsRunning = true;
        Counter = StartTimerTemplate;
        Counter.Invoke();
    }

    private async Task StartTimerTemplate()
    {
        while(IsRunning)
        {
            await _state.Wait(TicksPerSecond);
            Console.Clear();
            Console.WriteLine(_state);

            if (_state.IsZero)
            {
                await Stop();
            }
        }
    }

    public async Task Stop()
    {
        if(!IsRunning || Counter is null)
        {
            return;
        }

        IsRunning = false;
        await Counter.Invoke();
        Counter = null;
    }
}
