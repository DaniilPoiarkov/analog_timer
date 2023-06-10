using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.LetterPatterns.Implementations;

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
