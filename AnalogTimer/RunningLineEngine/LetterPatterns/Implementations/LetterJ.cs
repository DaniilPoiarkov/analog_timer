using RunningLineEngine.Contracts;

namespace RunningLineEngine.LetterPatterns.Implementations;

internal class LetterJ : ILetterPattern
{
    public List<string> Pattern => new()
    {
        "    █",
        "    █",
        "    █",
        "█   █",
        " ███ "
    };
}
