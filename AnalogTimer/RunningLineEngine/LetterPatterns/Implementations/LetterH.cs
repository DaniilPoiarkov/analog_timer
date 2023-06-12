using RunningLineEngine.Contracts;

namespace RunningLineEngine.LetterPatterns.Implementations;

internal class LetterH : ILetterPattern
{
    public List<string> Pattern => new()
    {
        "█    █",
        "█    █",
        "██████",
        "█    █",
        "█    █"
    };
}
