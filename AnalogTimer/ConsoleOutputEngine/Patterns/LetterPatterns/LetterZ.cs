using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.LetterPatterns;

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
