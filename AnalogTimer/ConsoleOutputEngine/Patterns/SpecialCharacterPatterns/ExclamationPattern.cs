using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.SpecialCharacterPatterns;

internal class ExclamationPattern : ICharacterPattern
{
    public List<string> Pattern => new()
    {
        " ██ ",
        " ██ ",
        " ██ ",
        "    ",
        " ██ "
    };
}
