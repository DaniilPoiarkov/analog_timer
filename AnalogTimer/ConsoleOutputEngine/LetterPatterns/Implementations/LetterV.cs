using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.LetterPatterns.Implementations;

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
