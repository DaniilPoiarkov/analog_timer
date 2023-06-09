using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.LetterPatterns.Implementations;

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
