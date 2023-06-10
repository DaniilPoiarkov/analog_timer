using ConsoleOutputEngine.Contracts;
using RunningLineEngine.Models;

namespace RunningLine.Contracts;

internal interface IRunningLineArgsOutputFormatter : IConsoleOutputFormatter
{
    void Update(RunningLineEventArgs args);
}
