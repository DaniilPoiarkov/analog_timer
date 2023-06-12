using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.LetterPatterns.Implementations;

internal class LetterY : ILetterPattern
{
    public List<string> Pattern => new()
    {
        "█     █",
        " █   █ ",
        "  █ █  ",
        "   █   ",
        "   █   "
    };
}
