using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.DigitPatterns;

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
