using ConsoleOutputEngine.Contracts;

namespace RunningLine.Patterns.DigitPatterns;

internal class TwoPattern : ICharacterPattern
{
    public List<string> Pattern => new()
    {
        "██████",
        "     █",
        "██████",
        "█     ",
        "██████",
    };
}
