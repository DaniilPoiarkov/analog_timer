using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.LetterPatterns.Implementations;

internal class LetterZ : ILetterPattern
{
    public List<string> Pattern => new()
    {
        "███████",
        "     █ ",
        "   █   ",
        " █     ",
        "███████"
    };
}
