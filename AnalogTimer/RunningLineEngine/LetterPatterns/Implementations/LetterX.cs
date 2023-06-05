using RunningLineEngine.Contracts;

namespace RunningLineEngine.LetterPatterns.Implementations;

internal class LetterX : ILetterPattern
{
    public List<string> Pattern => new()
    {
        "█     █",
        " █   █ ",
        "  █ █  ",
        " █   █ ",
        "█     █"
    };
}
