using RunningLineEngine.Contracts;

namespace RunningLineEngine.LetterPatterns.Implementations;

internal class EmptyLetter : ILetterPattern
{
    public List<string> Pattern => new()
    {
        "      ",
        "      ",
        "      ",
        "      ",
        "      ",
    };
}
