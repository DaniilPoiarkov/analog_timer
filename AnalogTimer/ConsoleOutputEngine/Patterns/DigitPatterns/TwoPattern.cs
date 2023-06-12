using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.DigitPatterns;

internal class TwoPattern : IDigitPattern
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
