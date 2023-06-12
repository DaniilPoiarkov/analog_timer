using ConsoleOutputEngine.Contracts;

namespace RunningLine.Patterns.SpecialCharacterPatterns;

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
