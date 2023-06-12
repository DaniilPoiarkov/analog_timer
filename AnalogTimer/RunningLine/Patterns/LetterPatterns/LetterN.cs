using ConsoleOutputEngine.Contracts;

namespace RunningLine.Patterns.LetterPatterns;

internal class LetterN : ICharacterPattern
{
    public List<string> Pattern => new()
    {
        "█     █",
        "██    █",
        "█ █   █",
        "█  █  █",
        "█   ███"
    };
}
