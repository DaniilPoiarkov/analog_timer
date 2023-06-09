using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.LetterPatterns.Implementations;

internal class LetterO : ILetterPattern
{
    public List<string> Pattern => new()
    {
        " █████ ",
        "█     █",
        "█     █",
        "█     █",
        " █████ "
    };
}
