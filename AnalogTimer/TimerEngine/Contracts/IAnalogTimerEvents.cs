using AnalogTimer.Models;
using TimerEngine.Models.TimerEventArgs;

namespace TimerEngine.Contracts;

public interface IAnalogTimerEvents
{
    event TimerTick? Tick;

    event TimerUpdated? Updated;

    event TimerUpdated? TimerStarted;

    event TimerUpdated? TimerCut;

    event TimerUpdated? Stopeed;


    public delegate void TimerTick(TimerState state);

    public delegate void TimerUpdated(TimerEventArgs state);
}
