using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.LetterPatterns.Implementations;

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
