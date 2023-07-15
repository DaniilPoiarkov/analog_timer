using ConsoleOutputEngine.Contracts;

namespace AnalogTimer.Patterns.DigitPatterns;

internal class FivePattern : ICharacterPattern
{
    public List<string> Pattern => new()
    {
        "██████",
        "█     ",
        "██████",
        "     █",
        "██████",
    };
}
