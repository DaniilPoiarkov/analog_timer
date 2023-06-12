using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.DigitPatterns.Implementations;

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
