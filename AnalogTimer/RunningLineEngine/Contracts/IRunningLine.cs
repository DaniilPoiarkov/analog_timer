using ConsoleInterface.EntityContracts;

namespace RunningLineEngine.Contracts;

public interface IRunningLine : ISpeedChangable
{
    Task Run(string sentence);
}
