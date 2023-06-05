using RunningLineEngine.Contracts;

namespace RunningLineEngine.LetterPatterns.Implementations;

internal class LetterW : ILetterPattern
{
    public List<string> Pattern => new()
    {
        "█       █",
        "█   █   █",
        "█  █ █  █",
        "█ █   █ █",
        "██     ██"
    };
}
