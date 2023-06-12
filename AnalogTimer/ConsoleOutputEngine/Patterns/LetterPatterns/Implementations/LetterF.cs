using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.LetterPatterns.Implementations;

internal class LetterF : ILetterPattern
{
    public List<string> Pattern => new()
    {
        "██████",
        "█     ",
        "█████ ",
        "█     ",
        "█     "
    };
}
