using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.LetterPatterns.Implementations;

internal class LetterB : ILetterPattern
{
    public List<string> Pattern => new()
    {
        "█████ ",
        "█    █",
        "█████ ",
        "█    █",
        "█████ "
    };
}
