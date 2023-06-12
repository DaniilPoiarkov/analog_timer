using ConsoleOutputEngine.Contracts;

namespace RunningLine.Patterns.DigitPatterns;

internal class SixPattern : ICharacterPattern
{
    public List<string> Pattern => new()
    {
        "██████",
        "█     ",
        "██████",
        "█    █",
        "██████",
    };
}
