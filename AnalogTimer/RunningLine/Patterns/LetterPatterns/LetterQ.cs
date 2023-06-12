using ConsoleOutputEngine.Contracts;

namespace RunningLine.Patterns.LetterPatterns;

internal class LetterQ : ICharacterPattern
{
    public List<string> Pattern => new()
    {
        " █████ ",
        "█     █",
        "█   █ █",
        "█    ██",
        " ██████"
    };
}
