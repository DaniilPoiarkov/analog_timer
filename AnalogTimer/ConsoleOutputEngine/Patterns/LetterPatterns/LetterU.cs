using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.LetterPatterns;

internal class LetterU : ILetterPattern
{
    public List<string> Pattern => new()
    {
        "█     █",
        "█     █",
        "█     █",
        "█     █",
        " █████ "
    };
}
