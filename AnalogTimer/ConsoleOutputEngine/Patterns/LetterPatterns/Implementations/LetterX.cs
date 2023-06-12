using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.LetterPatterns.Implementations;

internal class LetterX : ILetterPattern
{
    public List<string> Pattern => new()
    {
        "█     █",
        " █   █ ",
        "  █ █  ",
        " █   █ ",
        "█     █"
    };
}
