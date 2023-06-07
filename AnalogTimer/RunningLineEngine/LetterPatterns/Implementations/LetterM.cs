using RunningLineEngine.Contracts;

namespace RunningLineEngine.LetterPatterns.Implementations;

internal class LetterM : ILetterPattern
{
    public List<string> Pattern => new()
    {
        "█     █",
        "██   ██",
        "█ █ █ █",
        "█  █  █",
        "█     █"
    };
}
