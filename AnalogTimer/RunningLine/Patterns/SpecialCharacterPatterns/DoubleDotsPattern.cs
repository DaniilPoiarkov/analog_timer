using ConsoleOutputEngine.Contracts;

namespace RunningLine.Patterns.SpecialCharacterPatterns;

internal class DoubleDotsPattern : ICharacterPattern
{
    public List<string> Pattern => new()
    {
        "    ",
        " ██ ",
        "    ",
        " ██ ",
        "    "
    };
}
