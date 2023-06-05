using RunningLineEngine.Contracts;

namespace RunningLineEngine.LetterPatterns.Implementations;

internal class LetterL : ILetterPattern
{
    public List<string> Pattern => new()
    {
        "█     ",
        "█     ",
        "█     ",
        "█     ",
        "█████ "
    };
}
