using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.SpecialCharacterPatterns;

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
