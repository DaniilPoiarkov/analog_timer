using ConsoleOutputEngine.Contracts;

namespace RunningLine.Patterns.LetterPatterns;

internal class LetterV : ICharacterPattern
{
    public List<string> Pattern => new()
    {
        "█     █",
        "█     █",
        " █   █ ",
        "  █ █  ",
        "   █   "
    };
}
