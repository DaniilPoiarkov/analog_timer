using RunningLineEngine.Contracts;

namespace RunningLineEngine.LetterPatterns;

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
