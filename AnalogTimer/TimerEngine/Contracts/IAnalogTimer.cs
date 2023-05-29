using AnalogTimer.Models;
using ConsoleInterface.Contracts;
using ConsoleInterface.EntityContracts;
using TimerEngine.Contracts;
using TimerEngine.Models.Enums;

namespace AnalogTimer.Contracts;

public interface IAnalogTimer : ITimerEvents, ISpeedChangable, IAsyncRunnable
{
    void AddSeconds(int seconds);

    void AddMinutes(int minutes);

    void AddHours(int hours);

    void ResetState();

    void SetTimerType(TimerType type);

    TimerState GetSnapshot();

    void Cut();
}
