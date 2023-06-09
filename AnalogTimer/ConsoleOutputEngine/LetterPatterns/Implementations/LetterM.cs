using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.LetterPatterns.Implementations;

internal class LetterM : ILetterPattern
{
    public List<string> Pattern => new()
    {
        "█     █",
        "██   ██",
        "█ █ █ █",
        "█  █  █",
        "█     █"
    };
}
