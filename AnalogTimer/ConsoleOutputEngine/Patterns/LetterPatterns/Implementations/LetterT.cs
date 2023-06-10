using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.LetterPatterns.Implementations;

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
