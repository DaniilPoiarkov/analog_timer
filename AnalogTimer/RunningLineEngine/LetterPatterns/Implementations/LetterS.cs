using RunningLineEngine.Contracts;

namespace RunningLineEngine.LetterPatterns.Implementations;

internal class LetterS : ILetterPattern
{
    public List<string> Pattern => new()
    {
        " █████",
        "█     ",
        " █████",
        "     █",
        "█████ "
    };
}
