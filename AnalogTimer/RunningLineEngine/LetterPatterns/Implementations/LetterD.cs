using RunningLineEngine.Contracts;

namespace RunningLineEngine.LetterPatterns;

internal class LetterD : ILetterPattern
{
    public List<string> Pattern => new()
    {
        "█████ ",
        "█    █",
        "█    █",
        "█    █",
        "█████ "
    };
}
