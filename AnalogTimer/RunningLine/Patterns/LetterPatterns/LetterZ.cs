using ConsoleOutputEngine.Contracts;

namespace RunningLine.Patterns.LetterPatterns;

internal class LetterZ : ICharacterPattern
{
    public List<string> Pattern => new()
    {
        "███████",
        "     █ ",
        "   █   ",
        " █     ",
        "███████"
    };
}
