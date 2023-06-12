using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.SpecialCharacterPatterns;

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
