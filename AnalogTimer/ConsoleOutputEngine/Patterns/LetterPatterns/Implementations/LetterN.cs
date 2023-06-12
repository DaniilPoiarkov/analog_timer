using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.LetterPatterns.Implementations;

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
