namespace TimerEngine.Contracts;

public interface IAnalogTimerAsyncRunnable
{
    bool IsRunning { get; }

    void Start();

    Task Stop();
}
