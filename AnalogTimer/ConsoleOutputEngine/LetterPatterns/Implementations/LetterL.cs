using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.LetterPatterns.Implementations;

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
