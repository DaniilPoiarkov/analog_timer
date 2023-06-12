using ConsoleOutputEngine.Contracts;

namespace AnalogTimer.Patterns.SpecialCharacterPatterns;

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
