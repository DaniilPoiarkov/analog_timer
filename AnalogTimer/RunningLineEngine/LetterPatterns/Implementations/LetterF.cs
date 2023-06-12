using RunningLineEngine.Contracts;

namespace RunningLineEngine.LetterPatterns.Implementations;

internal class LetterF : ILetterPattern
{
    public List<string> Pattern => new()
    {
        "██████",
        "█     ",
        "█████ ",
        "█     ",
        "█     "
    };
}
