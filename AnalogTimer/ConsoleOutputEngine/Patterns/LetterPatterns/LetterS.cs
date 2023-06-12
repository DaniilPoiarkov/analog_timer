using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.LetterPatterns;

internal class LetterS : ILetterPattern
{
    public List<string> Pattern => new()
    {
        " █████",
        "█     ",
        " █████",
        "     █",
        "█████ "
    };
}
