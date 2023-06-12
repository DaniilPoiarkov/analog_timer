using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.DigitPatterns;

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
