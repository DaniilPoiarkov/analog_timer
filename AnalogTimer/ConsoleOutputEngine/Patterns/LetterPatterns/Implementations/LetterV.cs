using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.LetterPatterns.Implementations;

internal class LetterV : ILetterPattern
{
    public List<string> Pattern => new()
    {
        "█     █",
        "█     █",
        " █   █ ",
        "  █ █  ",
        "   █   "
    };
}
