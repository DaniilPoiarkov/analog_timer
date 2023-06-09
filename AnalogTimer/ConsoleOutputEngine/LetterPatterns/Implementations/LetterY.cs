using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.LetterPatterns.Implementations;

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
