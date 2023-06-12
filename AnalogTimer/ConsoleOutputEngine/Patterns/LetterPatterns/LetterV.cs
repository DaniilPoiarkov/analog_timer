using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.LetterPatterns;

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
