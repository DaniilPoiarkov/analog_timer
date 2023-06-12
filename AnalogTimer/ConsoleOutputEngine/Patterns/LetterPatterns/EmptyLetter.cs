using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.LetterPatterns;

internal class EmptyLetter : ILetterPattern
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
