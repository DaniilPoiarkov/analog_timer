using ConsoleOutputEngine.Contracts;

namespace AnalogTimer.Patterns.DigitPatterns;

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
