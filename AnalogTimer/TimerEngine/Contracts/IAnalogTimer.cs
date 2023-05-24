using AnalogTimer.Models;
using AnalogTimer.Models.Enums;
using TimerEngine.Contracts;

namespace AnalogTimer.Contracts;

public interface IAnalogTimer : ITimerEvents
{
    bool IsRunning { get; }

    void Start();

    Task Stop();

    void AddSeconds(int seconds);

    void AddMinutes(int minutes);

    void AddHours(int hours);

    void ChangeTicksPerSecond(int ticksPerSecond);

    void ResetState();

    void SetTimerType(TimerType type);

    TimerState GetSnapshot();

    void Cut();
}
