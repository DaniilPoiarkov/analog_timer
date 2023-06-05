using RunningLineEngine.Contracts;

namespace RunningLineEngine.LetterPatterns.Implementations;

internal class LetterA : ILetterPattern
{
    public List<string> Pattern => new()
    {
        "  ██  ",
        " ████ ",
        "█    █",
        "██████",
        "█    █",
    };
}
