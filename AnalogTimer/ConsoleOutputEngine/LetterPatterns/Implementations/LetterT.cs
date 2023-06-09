using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.LetterPatterns.Implementations;

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
