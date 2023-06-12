using ConsoleOutputEngine.Contracts;

namespace RunningLine.Patterns.DigitPatterns;

internal class FivePattern : ICharacterPattern
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
