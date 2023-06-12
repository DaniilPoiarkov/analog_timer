using ConsoleOutputEngine.Contracts;

namespace RunningLine.Patterns.DigitPatterns;

internal class ZeroPattern : ICharacterPattern
{
    public List<string> Pattern => new()
    {
        "██████",
        "█    █",
        "█    █",
        "█    █",
        "██████",
    };
}
