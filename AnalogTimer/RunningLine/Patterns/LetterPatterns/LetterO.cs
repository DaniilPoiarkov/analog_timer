using ConsoleOutputEngine.Contracts;

namespace RunningLine.Patterns.LetterPatterns;

internal class LetterO : ICharacterPattern
{
    public List<string> Pattern => new()
    {
        " █████ ",
        "█     █",
        "█     █",
        "█     █",
        " █████ "
    };
}
