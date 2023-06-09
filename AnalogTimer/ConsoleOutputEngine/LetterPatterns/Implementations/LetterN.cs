using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.LetterPatterns.Implementations;

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
