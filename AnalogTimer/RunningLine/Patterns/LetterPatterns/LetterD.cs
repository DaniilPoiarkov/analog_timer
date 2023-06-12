using ConsoleOutputEngine.Contracts;

namespace RunningLine.Patterns.LetterPatterns;

internal class LetterD : ICharacterPattern
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
