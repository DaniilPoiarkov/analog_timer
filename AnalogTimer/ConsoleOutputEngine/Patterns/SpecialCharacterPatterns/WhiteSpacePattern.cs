using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.SpecialCharacterPatterns;

internal class WhiteSpacePattern : ILetterPattern
{
    public List<string> Pattern => new()
    {
        "      ",
        "      ",
        "      ",
        "      ",
        "      ",
    };
}
