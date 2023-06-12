using ConsoleOutputEngine.Contracts;

namespace RunningLine.Patterns.LetterPatterns;

internal class LetterA : ICharacterPattern
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
