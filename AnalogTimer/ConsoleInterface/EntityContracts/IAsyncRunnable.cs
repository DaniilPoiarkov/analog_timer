namespace ConsoleInterface.EntityContracts;

public interface IAsyncRunnable
{
    bool IsRunning { get; }

    void Start();

    Task Stop();
}
