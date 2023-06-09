using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.LetterPatterns.Implementations;

internal class LetterA : ILetterPattern
{
    public List<string> Pattern => new()
    {
        "  ██  ",
        " ████ ",
        "█    █",
        "██████",
        "█    █",
    };
}
