using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.LetterPatterns.Implementations;

internal class LetterJ : ILetterPattern
{
    public List<string> Pattern => new()
    {
        "    █",
        "    █",
        "    █",
        "█   █",
        " ███ "
    };
}
