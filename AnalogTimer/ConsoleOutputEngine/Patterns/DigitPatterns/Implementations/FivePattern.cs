using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.DigitPatterns.Implementations;

internal class FivePattern : IDigitPattern
{
    public List<string> Pattern => new()
    {
        "██████",
        "█     ",
        "██████",
        "     █",
        "██████",
    };
}
