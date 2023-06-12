using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.LetterPatterns;

internal class LetterW : ILetterPattern
{
    public List<string> Pattern => new()
    {
        "█       █",
        "█   █   █",
        "█  █ █  █",
        "█ █   █ █",
        "██     ██"
    };
}
