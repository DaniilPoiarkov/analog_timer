using RunningLineEngine.Contracts;

namespace RunningLineEngine.LetterPatterns.Implementations;

internal class LetterV : ILetterPattern
{
    public List<string> Pattern => new()
    {
        "█     █",
        "█     █",
        " █   █ ",
        "  █ █  ",
        "   █   "
    };
}
