using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.LetterPatterns.Implementations;

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
