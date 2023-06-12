using ConsoleOutputEngine.Contracts;

namespace AnalogTimer.Patterns.DigitPatterns;

internal class ThreePattern : ICharacterPattern
{
    public List<string> Pattern => new()
    {
        "██████",
        "     █",
        "██████",
        "     █",
        "██████",
    };
}
