using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.LetterPatterns.Implementations;

internal class EmptyLetter : ILetterPattern
{
    public List<string> Pattern => new()
    {
        "      ",
        "      ",
        "      ",
        "      ",
        "      ",
    };
}
