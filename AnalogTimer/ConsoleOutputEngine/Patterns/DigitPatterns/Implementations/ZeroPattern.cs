using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.DigitPatterns.Implementations;

internal class ZeroPattern : IDigitPattern
{
    public List<string> Pattern => new()
    {
        "██████",
        "█    █",
        "█    █",
        "█    █",
        "██████",
    };
}
