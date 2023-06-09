using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.LetterPatterns.Implementations;

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
