using RunningLineEngine.Contracts;

namespace RunningLineEngine.LetterPatterns;

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
