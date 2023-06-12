using ConsoleOutputEngine.Contracts;

namespace RunningLine.Patterns.DigitPatterns;

internal class SevenPattern : ICharacterPattern
{
    public List<string> Pattern => new()
    {
        "██████",
        "     █",
        "     █",
        "     █",
        "     █",
    };
}
