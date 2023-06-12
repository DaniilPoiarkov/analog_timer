using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.LetterPatterns.Implementations;

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
