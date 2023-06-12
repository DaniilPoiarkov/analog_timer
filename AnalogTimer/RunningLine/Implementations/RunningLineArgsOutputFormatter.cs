using RunningLine.Contracts;
using RunningLineEngine.Models;

namespace RunningLine.Implementations;

internal class RunningLineArgsOutputFormatter : IRunningLineArgsOutputFormatter
{
    private RunningLineEventArgs? _args;

    public IEnumerable<string> Format(IEnumerable<string> pattern)
    {
        if (_args is null || _args.IndexStart == 0 && _args.IndexEnd == 0)
        {
            return pattern;
        }

        if (_args.IndexStart != 0 && _args.IndexEnd != 0)
        {
            return pattern.Select(p => p[_args.IndexStart.._args.IndexEnd]);
        }

        if (_args.IndexStart != 0 && _args.IndexEnd == 0)
        {
            return pattern.Select(p => p[_args.IndexStart..]);
        }

        if (_args.IndexEnd != 0)
        {
            return pattern.Select(p => p[.._args.IndexEnd]);
        }

        return pattern;
    }

    public void Update(RunningLineEventArgs args)
    {
        _args = args;
    }
}
