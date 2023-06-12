using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.LetterPatterns;

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
