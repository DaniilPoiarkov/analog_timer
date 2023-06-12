using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.DigitPatterns;

internal class OnePattern : IDigitPattern
{
    public List<string> Pattern => new()
    {
        "     █",
        "     █",
        "     █",
        "     █",
        "     █",
    };
}
