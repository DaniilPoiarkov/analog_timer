using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.LetterPatterns.Implementations;

internal class LetterL : ILetterPattern
{
    public List<string> Pattern => new()
    {
        "█     ",
        "█     ",
        "█     ",
        "█     ",
        "█████ "
    };
}
