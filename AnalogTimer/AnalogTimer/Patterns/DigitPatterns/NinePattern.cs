using ConsoleOutputEngine.Contracts;

namespace AnalogTimer.Patterns.DigitPatterns;

internal class NinePattern : ICharacterPattern
{
    public List<string> Pattern => new()
    {
        "██████",
        "█    █",
        "██████",
        "     █",
        "██████",
    };
}
