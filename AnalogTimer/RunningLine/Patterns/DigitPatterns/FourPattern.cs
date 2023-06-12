using ConsoleOutputEngine.Contracts;

namespace RunningLine.Patterns.DigitPatterns;

internal class FourPattern : ICharacterPattern
{
    public List<string> Pattern => new()
    {
        "█    █",
        "█    █",
        "██████",
        "     █",
        "     █",
    };
}
