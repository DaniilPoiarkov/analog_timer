using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.LetterPatterns.Implementations;

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
