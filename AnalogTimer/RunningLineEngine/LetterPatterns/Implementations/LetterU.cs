using RunningLineEngine.Contracts;

namespace RunningLineEngine.LetterPatterns.Implementations;

internal class LetterU : ILetterPattern
{
    public List<string> Pattern => new()
    {
        "█     █",
        "█     █",
        "█     █",
        "█     █",
        " █████ "
    };
}
