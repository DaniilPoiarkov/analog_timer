using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.SpecialCharacterPatterns;

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
