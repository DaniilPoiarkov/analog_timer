using RunningLineEngine.Contracts;

namespace RunningLineEngine.LetterPatterns.Implementations;

internal class LetterZ : ILetterPattern
{
    public List<string> Pattern => new()
    {
        "███████",
        "     █ ",
        "   █   ",
        " █     ",
        "███████"
    };
}
