using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.LetterPatterns;

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
