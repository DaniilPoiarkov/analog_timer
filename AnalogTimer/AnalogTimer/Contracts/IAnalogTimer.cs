namespace AnalogTimer.Contracts;

public interface IAnalogTimer
{
    void Start();

    Task Stop();

    void AddSeconds(int seconds);
}
