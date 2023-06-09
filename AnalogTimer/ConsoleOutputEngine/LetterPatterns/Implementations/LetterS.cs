using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.LetterPatterns.Implementations;

internal class LetterS : ILetterPattern
{
    public List<string> Pattern => new()
    {
        " █████",
        "█     ",
        " █████",
        "     █",
        "█████ "
    };
}
