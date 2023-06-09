using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.LetterPatterns.Implementations;

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
