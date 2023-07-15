using ConsoleOutputEngine.Contracts;

namespace RunningLine.Patterns.LetterPatterns;

internal class LetterS : ICharacterPattern
{
    public List<string> Pattern => new()
    {
        " █████",
        "█     ",
        " █████",
        "     █",
        "█████ "
    };
}
