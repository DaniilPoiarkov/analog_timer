using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.LetterPatterns.Implementations;

internal class LetterI : ILetterPattern
{
    public List<string> Pattern => new()
    {
        "█████",
        "  █  ",
        "  █  ",
        "  █  ",
        "█████"
    };
}
