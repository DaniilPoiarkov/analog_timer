using RunningLineEngine.Contracts;

namespace RunningLineEngine.LetterPatterns.Implementations;

internal class LetterG : ILetterPattern
{
    public List<string> Pattern => new()
    {
        " █████",
        "█     ",
        "█  ███",
        "█    █",
        " █████"
    };
}
