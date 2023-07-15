using ConsoleOutputEngine.Contracts;

namespace RunningLine.Patterns.LetterPatterns;

internal class LetterM : ICharacterPattern
{
    public List<string> Pattern => new()
    {
        "█     █",
        "██   ██",
        "█ █ █ █",
        "█  █  █",
        "█     █"
    };
}
