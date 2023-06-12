using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.SpecialCharacterPatterns;

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
