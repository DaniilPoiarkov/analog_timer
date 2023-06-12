using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.DigitPatterns;

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
