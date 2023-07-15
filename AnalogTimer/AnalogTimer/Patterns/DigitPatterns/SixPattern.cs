using ConsoleOutputEngine.Contracts;

namespace AnalogTimer.Patterns.DigitPatterns;

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
