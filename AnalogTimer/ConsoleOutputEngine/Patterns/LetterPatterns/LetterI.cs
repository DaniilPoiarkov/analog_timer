using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.LetterPatterns;

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
