using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.DigitPatterns;

internal class EightPattern : IDigitPattern
{
    public List<string> Pattern => new()
    {
        "██████",
        "█    █",
        "██████",
        "█    █",
        "██████",
    };
}
