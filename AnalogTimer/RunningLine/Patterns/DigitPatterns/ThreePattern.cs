using ConsoleOutputEngine.Contracts;

namespace RunningLine.Patterns.DigitPatterns;

internal class ThreePattern : ICharacterPattern
{
    public List<string> Pattern => new()
    {
        "██████",
        "     █",
        "██████",
        "     █",
        "██████",
    };
}
