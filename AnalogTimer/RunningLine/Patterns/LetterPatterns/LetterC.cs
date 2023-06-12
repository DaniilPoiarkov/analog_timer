using ConsoleOutputEngine.Contracts;

namespace RunningLine.Patterns.LetterPatterns;

internal class LetterC : ICharacterPattern
{
    public List<string> Pattern => new()
    {
        " █████",
        "█     ",
        "█     ",
        "█     ",
        " █████"
    };
}
