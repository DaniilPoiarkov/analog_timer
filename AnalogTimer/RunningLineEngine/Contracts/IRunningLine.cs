using ConsoleInterface.EntityContracts;

namespace RunningLineEngine.Contracts;

public interface IRunningLine : ISpeedChangable, IAsyncRunnable
{
    void Set(string sentence);

    void Clean();
}
