using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.LetterPatterns;

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
