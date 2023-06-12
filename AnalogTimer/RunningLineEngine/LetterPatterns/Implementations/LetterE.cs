using RunningLineEngine.Contracts;

namespace RunningLineEngine.LetterPatterns.Implementations;

internal class LetterE : ILetterPattern
{
    public List<string> Pattern => new()
    {
        "██████",
        "█     ",
        "█████ ",
        "█     ",
        "██████"
    };
}
