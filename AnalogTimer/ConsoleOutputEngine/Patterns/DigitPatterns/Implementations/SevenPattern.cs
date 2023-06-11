using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.DigitPatterns.Implementations;

internal class SevenPattern : IDigitPattern
{
    public List<string> Pattern => new()
    {
        //"████████",
        //"       █",
        //"       █",
        //"       █",
        //"       █",
        //"       █",
        //"       █",
        "██████",
        "     █",
        "     █",
        "     █",
        "     █",
    };
}
