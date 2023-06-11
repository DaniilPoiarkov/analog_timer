using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.DigitPatterns.Implementations;

internal class SixPattern : IDigitPattern
{
    public List<string> Pattern => new()
    {
        "██████",
        "█     ",
        "██████",
        "█    █",
        "██████",
    };
}
