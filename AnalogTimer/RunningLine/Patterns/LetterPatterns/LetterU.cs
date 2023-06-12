using ConsoleOutputEngine.Contracts;

namespace RunningLine.Patterns.LetterPatterns;

internal class LetterU : ICharacterPattern
{
    public List<string> Pattern => new()
    {
        "█     █",
        "█     █",
        "█     █",
        "█     █",
        " █████ "
    };
}
