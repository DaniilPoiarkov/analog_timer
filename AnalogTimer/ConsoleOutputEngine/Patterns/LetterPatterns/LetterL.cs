using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.LetterPatterns;

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
