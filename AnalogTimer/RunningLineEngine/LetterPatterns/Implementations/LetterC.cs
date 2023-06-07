using RunningLineEngine.Contracts;

namespace RunningLineEngine.LetterPatterns.Implementations;

internal class LetterC : ILetterPattern
{
    public List<string> Pattern => new()
    {
        " █████",
        "█     ",
        "█     ",
        "█     ",
        " █████"
    };
}
