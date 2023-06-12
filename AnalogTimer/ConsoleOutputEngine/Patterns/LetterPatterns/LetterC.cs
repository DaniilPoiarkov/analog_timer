using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.LetterPatterns;

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
