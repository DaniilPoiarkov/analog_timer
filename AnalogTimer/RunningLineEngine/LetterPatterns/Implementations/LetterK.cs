using RunningLineEngine.Contracts;

namespace RunningLineEngine.LetterPatterns.Implementations;

internal class LetterK : ILetterPattern
{
    public List<string> Pattern => new()
    {
        "█   █",
        "█  █ ",
        "███  ",
        "█  █ ",
        "█   █"
    };
}
