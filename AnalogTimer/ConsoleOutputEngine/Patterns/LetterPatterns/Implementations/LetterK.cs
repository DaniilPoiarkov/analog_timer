using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.LetterPatterns.Implementations;

internal class LetterK : ILetterPattern
{
    public List<string> Pattern => new()
    {
        "█   █",
        "█  █ ",
        "███  ",
        "█  █ ",
        "█   █"
    };
}
