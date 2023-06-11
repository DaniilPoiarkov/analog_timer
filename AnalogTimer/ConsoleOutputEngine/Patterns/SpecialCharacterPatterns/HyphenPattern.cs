using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.SpecialCharacterPatterns;

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
