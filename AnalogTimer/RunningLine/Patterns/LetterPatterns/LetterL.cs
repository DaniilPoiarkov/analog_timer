using ConsoleOutputEngine.Contracts;

namespace RunningLine.Patterns.LetterPatterns;

internal class LetterL : ICharacterPattern
{
    public List<string> Pattern => new()
    {
        "█     ",
        "█     ",
        "█     ",
        "█     ",
        "█████ "
    };
}
