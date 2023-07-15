using RunningLineEngine.Models;

namespace RunningLine.Contracts;

internal interface IRunningLineArgsOutputFormatter
{
    IEnumerable<string> Format(IEnumerable<string> pattern);

    void Update(RunningLineEventArgs args);
}
