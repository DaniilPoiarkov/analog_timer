using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.LetterPatterns;

internal class LetterT : ILetterPattern
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
