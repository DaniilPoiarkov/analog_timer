using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.LetterPatterns.Implementations;

internal class LetterE : ILetterPattern
{
    public List<string> Pattern => new()
    {
        "██████",
        "█     ",
        "█████ ",
        "█     ",
        "██████"
    };
}
