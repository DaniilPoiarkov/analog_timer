using ConsoleOutputEngine.Contracts;

namespace AnalogTimer.Patterns.DigitPatterns;

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
