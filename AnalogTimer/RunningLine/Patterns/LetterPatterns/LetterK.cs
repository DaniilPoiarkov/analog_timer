using ConsoleOutputEngine.Contracts;

namespace RunningLine.Patterns.LetterPatterns;

internal class LetterK : ICharacterPattern
{
    public List<string> Pattern => new()
    {
        "█   █",
        "█  █ ",
        "███  ",
        "█  █ ",
        "█   █"
    };
}
