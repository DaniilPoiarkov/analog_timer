using RunningLineEngine.Contracts;

namespace RunningLineEngine.LetterPatterns.Implementations;

internal class LetterN : ILetterPattern
{
    public List<string> Pattern => new()
    {
        "█     █",
        "██    █",
        "█ █   █",
        "█  █  █",
        "█   ███"
    };
}
