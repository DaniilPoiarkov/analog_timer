using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Implementations;

internal class DefaultConsoleOutputFormatter : IConsoleOutputFormatter
{
    public IEnumerable<string> Format(IEnumerable<string> pattern)
    {
        return pattern;
    }
}
