using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.LetterPatterns;

internal class LetterN : ILetterPattern
{
    public List<string> Pattern => new()
    {
        "█     █",
        "██    █",
        "█ █   █",
        "█  █  █",
        "█   ███"
    };
}
