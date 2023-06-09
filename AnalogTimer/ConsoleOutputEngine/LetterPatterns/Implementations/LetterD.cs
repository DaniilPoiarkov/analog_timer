using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.LetterPatterns.Implementations;

internal class LetterD : ILetterPattern
{
    public List<string> Pattern => new()
    {
        "█████ ",
        "█    █",
        "█    █",
        "█    █",
        "█████ "
    };
}
