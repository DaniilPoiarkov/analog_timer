using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.LetterPatterns.Implementations;

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
