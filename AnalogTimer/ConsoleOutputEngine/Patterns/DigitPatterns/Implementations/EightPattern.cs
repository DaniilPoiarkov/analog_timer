using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.DigitPatterns.Implementations;

internal class EightPattern : IDigitPattern
{
    public List<string> Pattern => new()
    {
        //"████████",
        //"█      █",
        //"█      █",
        //"████████",
        //"█      █",
        //"█      █",
        //"████████",
        "██████",
        "█    █",
        "██████",
        "█    █",
        "██████",
    };
}
