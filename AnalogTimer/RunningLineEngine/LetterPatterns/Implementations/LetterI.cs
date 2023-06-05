using RunningLineEngine.Contracts;

namespace RunningLineEngine.LetterPatterns.Implementations;

internal class LetterI : ILetterPattern
{
    public List<string> Pattern => new()
    {
        "█████",
        "  █  ",
        "  █  ",
        "  █  ",
        "█████"
    };
}
