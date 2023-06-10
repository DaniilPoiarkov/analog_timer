using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.SpecialCharacterPatterns;

internal class CommaPattern : ICharacterPattern
{
    public List<string> Pattern => new()
    {
        "    ",
        "    ",
        "    ",
        " ██ ",
        " ██ "
    };
}
