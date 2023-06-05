using RunningLineEngine.Contracts;

namespace RunningLineEngine.LetterPatterns.Implementations;

internal class LetterO : ILetterPattern
{
    public List<string> Pattern => new()
    {
        " █████ ",
        "█     █",
        "█     █",
        "█     █",
        " █████ "
    };
}
