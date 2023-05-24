namespace ConsoleInterface.Contracts;

public interface IAsyncRunnable
{
    bool IsRunning { get; }

    void Start();

    Task Stop();
}
