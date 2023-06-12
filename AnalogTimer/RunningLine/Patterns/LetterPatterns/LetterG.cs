using ConsoleOutputEngine.Contracts;

namespace RunningLine.Patterns.LetterPatterns;

internal class LetterG : ICharacterPattern
{
    public List<string> Pattern => new()
    {
        " █████",
        "█     ",
        "█  ███",
        "█    █",
        " █████"
    };
}
