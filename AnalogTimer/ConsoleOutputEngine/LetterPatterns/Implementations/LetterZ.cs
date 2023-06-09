using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.LetterPatterns.Implementations;

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
