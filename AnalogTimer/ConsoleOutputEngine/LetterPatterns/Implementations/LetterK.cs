using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.LetterPatterns.Implementations;

internal class LetterK : ILetterPattern
{
    public List<string> Pattern => new()
    {
        "█   █",
        "█  █ ",
        "███  ",
        "█  █ ",
        "█   █"
    };
}
