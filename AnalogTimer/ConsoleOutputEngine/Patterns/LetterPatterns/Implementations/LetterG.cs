using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.LetterPatterns.Implementations;

internal class LetterG : ILetterPattern
{
    public List<string> Pattern => new()
    {
        " █████",
        "█     ",
        "█  ███",
        "█    █",
        " █████"
    };
}
