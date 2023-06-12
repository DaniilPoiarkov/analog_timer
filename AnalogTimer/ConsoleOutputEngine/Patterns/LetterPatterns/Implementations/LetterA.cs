using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.LetterPatterns.Implementations;

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
