using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.DigitPatterns;

internal class SevenPattern : IDigitPattern
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
