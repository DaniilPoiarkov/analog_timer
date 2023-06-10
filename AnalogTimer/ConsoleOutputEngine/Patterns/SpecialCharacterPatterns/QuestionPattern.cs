using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.SpecialCharacterPatterns;

internal class QuestionPattern : ICharacterPattern
{
    public List<string> Pattern => new()
    {
        " ███ ",
        "    █",
        "  ██ ",
        "     ",
        "  ██ "
    };
}
