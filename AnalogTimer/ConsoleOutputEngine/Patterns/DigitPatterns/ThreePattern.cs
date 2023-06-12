using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.DigitPatterns;

internal class ThreePattern : IDigitPattern
{
    public List<string> Pattern => new()
    {
        "██████",
        "     █",
        "██████",
        "     █",
        "██████",
    };
}
