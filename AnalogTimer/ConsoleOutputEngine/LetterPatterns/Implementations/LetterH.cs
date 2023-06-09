using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.LetterPatterns.Implementations;

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
