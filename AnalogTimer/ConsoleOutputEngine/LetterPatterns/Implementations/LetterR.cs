using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.LetterPatterns.Implementations;

internal class LetterR : ILetterPattern
{
    public List<string> Pattern => new()
    {
        "█████ ",
        "█    █",
        "█████ ",
        "█   █ ",
        "█    █"
    };
}
