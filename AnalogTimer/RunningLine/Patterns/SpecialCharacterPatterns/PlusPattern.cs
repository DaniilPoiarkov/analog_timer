using ConsoleOutputEngine.Contracts;

namespace RunningLine.Patterns.SpecialCharacterPatterns;

internal class PlusPattern : ICharacterPattern
{
    public List<string> Pattern => new()
    {
        "       ",
        "   █   ",
        "███████",
        "   █   ",
        "       ",
    };
}
