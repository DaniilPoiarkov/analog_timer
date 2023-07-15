using ConsoleOutputEngine.Contracts;

namespace RunningLine.Patterns.LetterPatterns;

internal class LetterT : ICharacterPattern
{
    public List<string> Pattern => new()
    {
        "███████",
        "   █   ",
        "   █   ",
        "   █   ",
        "   █   "
    };
}
