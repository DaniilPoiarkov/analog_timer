namespace TimerEngine.Contracts;

public interface IAnalogTimerSpeed
{
    void ChangeSpeed(int coefficient);

    int TicksPerSecond { get; }
}
