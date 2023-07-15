using ConsoleOutputEngine.Contracts;

namespace RunningLine.Patterns.SpecialCharacterPatterns;

internal class HyphenPattern : ICharacterPattern
{
    public List<string> Pattern => new()
    {
        "       ",
        "       ",
        "███████",
        "       ",
        "       ",
    };
}
