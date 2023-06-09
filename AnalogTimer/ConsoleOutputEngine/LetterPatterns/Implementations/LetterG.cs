using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.LetterPatterns.Implementations;

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
