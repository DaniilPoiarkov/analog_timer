using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.LetterPatterns;

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
