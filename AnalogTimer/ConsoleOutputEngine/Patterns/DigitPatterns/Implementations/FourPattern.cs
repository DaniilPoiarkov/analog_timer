using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.DigitPatterns.Implementations;

internal class FourPattern : IDigitPattern
{
    public List<string> Pattern => new()
    {
        "█    █",
        "█    █",
        "██████",
        "     █",
        "     █",
    };
}
