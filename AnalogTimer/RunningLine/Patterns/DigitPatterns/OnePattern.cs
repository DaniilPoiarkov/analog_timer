using ConsoleOutputEngine.Contracts;

namespace RunningLine.Patterns.DigitPatterns;

internal class OnePattern : ICharacterPattern
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
