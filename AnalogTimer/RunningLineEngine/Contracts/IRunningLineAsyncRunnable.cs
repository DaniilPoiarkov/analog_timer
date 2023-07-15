namespace RunningLineEngine.Contracts;

public interface IRunningLineAsyncRunnable
{
    bool IsRunning { get; }

    void Start();

    Task Stop();
}
