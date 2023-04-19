using AnalogTimer.Models.Enums;

namespace AnalogTimer.Contracts;

public interface IAnalogTimer
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
}
