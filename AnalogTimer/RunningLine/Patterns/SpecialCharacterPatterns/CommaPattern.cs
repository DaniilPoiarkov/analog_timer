using ConsoleOutputEngine.Contracts;

namespace RunningLine.Patterns.SpecialCharacterPatterns;

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
