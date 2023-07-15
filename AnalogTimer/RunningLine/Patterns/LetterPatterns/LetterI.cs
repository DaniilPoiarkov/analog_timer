using ConsoleOutputEngine.Contracts;

namespace RunningLine.Patterns.LetterPatterns;

internal class LetterI : ICharacterPattern
{
    public List<string> Pattern => new()
    {
        "█████",
        "  █  ",
        "  █  ",
        "  █  ",
        "█████"
    };
}
