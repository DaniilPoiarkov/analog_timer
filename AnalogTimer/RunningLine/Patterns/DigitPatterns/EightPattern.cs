using ConsoleOutputEngine.Contracts;

namespace RunningLine.Patterns.DigitPatterns;

internal class EightPattern : ICharacterPattern
{
    public List<string> Pattern => new()
    {
        "██████",
        "█    █",
        "██████",
        "█    █",
        "██████",
    };
}
