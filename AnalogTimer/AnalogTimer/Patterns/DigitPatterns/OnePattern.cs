using ConsoleOutputEngine.Contracts;

namespace AnalogTimer.Patterns.DigitPatterns;

internal class OnePattern : ICharacterPattern
{
    public List<string> Pattern => new()
    {
        "     █",
        "     █",
        "     █",
        "     █",
        "     █",
    };
}
