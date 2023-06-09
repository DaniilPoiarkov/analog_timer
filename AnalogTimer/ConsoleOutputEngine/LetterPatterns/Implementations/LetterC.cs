using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.LetterPatterns.Implementations;

internal class LetterC : ILetterPattern
{
    public List<string> Pattern => new()
    {
        " █████",
        "█     ",
        "█     ",
        "█     ",
        " █████"
    };
}
