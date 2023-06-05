using RunningLineEngine.Contracts;

namespace RunningLineEngine.LetterPatterns.Implementations;

internal class LetterQ : ILetterPattern
{
    public List<string> Pattern => new()
    {
        " █████ ",
        "█     █",
        "█   █ █",
        "█    ██",
        " ██████"
    };
}
