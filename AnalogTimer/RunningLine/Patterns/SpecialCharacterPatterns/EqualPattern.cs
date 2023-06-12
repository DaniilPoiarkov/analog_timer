using ConsoleOutputEngine.Contracts;

namespace RunningLine.Patterns.SpecialCharacterPatterns;

internal class EqualPattern : ICharacterPattern
{
    public List<string> Pattern => new()
    {
        "       ",
        "███████",
        "       ",
        "███████",
        "       ",
    };
}
