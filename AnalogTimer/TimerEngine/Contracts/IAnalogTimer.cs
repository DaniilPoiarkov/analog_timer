using AnalogTimer.Models;
using ConsoleInterface.EntityContracts;
using TimerEngine.Contracts;
using TimerEngine.Models.Enums;

namespace AnalogTimer.Contracts;

public interface IAnalogTimer : ITimerEvents, ISpeedChangable
{
    bool IsRunning { get; }

    void Start();

    Task Stop();

    void AddSeconds(int seconds);

    void AddMinutes(int minutes);

    void AddHours(int hours);

    void ResetState();

    void SetTimerType(TimerType type);

    TimerState GetSnapshot();

    void Cut();
}
