using AnalogTimer.Models;
using TimerEngine.Contracts;
using TimerEngine.Models.Enums;

namespace AnalogTimer.Contracts;

public interface IAnalogTimer : IAnalogTimerEvents, IAnalogTimerSpeed, IAnalogTimerAsyncRunnable, IAnalogTimerStateChangable
{
    void SetTimerType(TimerType type);

    TimerState GetSnapshot();

    void Cut();
}
