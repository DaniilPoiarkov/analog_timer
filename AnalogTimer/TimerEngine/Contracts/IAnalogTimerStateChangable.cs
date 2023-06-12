namespace TimerEngine.Contracts;

public interface IAnalogTimerStateChangable
{
    void AddSeconds(int seconds);

    void AddMinutes(int minutes);

    void AddHours(int hours);

    void ResetState();
}
