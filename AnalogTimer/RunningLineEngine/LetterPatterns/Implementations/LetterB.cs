using RunningLineEngine.Contracts;

namespace RunningLineEngine.LetterPatterns;

internal class LetterB : ILetterPattern
{
    public List<string> Pattern => new()
    {
        "█████ ",
        "█    █",
        "█████ ",
        "█    █",
        "█████ "
    };
}
