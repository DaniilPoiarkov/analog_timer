using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.DigitPatterns;

internal class NinePattern : IDigitPattern
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
