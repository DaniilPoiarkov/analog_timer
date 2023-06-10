using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.LetterPatterns.Implementations;

internal class LetterH : ILetterPattern
{
    public List<string> Pattern => new()
    {
        "█    █",
        "█    █",
        "██████",
        "█    █",
        "█    █"
    };
}
