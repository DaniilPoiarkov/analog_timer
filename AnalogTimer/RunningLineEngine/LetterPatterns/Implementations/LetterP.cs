using RunningLineEngine.Contracts;

namespace RunningLineEngine.LetterPatterns.Implementations;

internal class LetterP : ILetterPattern
{
    public List<string> Pattern => new()
    {
        "█████ ",
        "█    █",
        "█████ ",
        "█     ",
        "█     "
    };
}
