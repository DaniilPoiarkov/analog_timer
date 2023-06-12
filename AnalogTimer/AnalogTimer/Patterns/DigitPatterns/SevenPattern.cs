using ConsoleOutputEngine.Contracts;

namespace AnalogTimer.Patterns.DigitPatterns;

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
