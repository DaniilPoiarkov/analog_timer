using ConsoleOutputEngine.Contracts;

namespace RunningLine.Patterns.LetterPatterns;

internal class LetterJ : ICharacterPattern
{
    public List<string> Pattern => new()
    {
        "    █",
        "    █",
        "    █",
        "█   █",
        " ███ "
    };
}
