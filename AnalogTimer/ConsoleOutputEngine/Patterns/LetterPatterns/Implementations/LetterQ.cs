using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.LetterPatterns.Implementations;

internal class LetterQ : ILetterPattern
{
    public List<string> Pattern => new()
    {
        " █████ ",
        "█     █",
        "█   █ █",
        "█    ██",
        " ██████"
    };
}
