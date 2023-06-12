using ConsoleOutputEngine.Contracts;

namespace RunningLine.Patterns.SpecialCharacterPatterns;

internal class DotPattern : ICharacterPattern
{
    public List<string> Pattern => new()
    {
        "    ",
        "    ",
        "    ",
        "    ",
        " ██ "
    };
}
