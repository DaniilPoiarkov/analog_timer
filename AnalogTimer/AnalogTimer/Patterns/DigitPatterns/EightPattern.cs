using ConsoleOutputEngine.Contracts;

namespace AnalogTimer.Patterns.DigitPatterns;

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
