using ConsoleOutputEngine.Contracts;

namespace RunningLine.Patterns.LetterPatterns;

internal class LetterW : ICharacterPattern
{
    public List<string> Pattern => new()
    {
        "█       █",
        "█   █   █",
        "█  █ █  █",
        "█ █   █ █",
        "██     ██"
    };
}
