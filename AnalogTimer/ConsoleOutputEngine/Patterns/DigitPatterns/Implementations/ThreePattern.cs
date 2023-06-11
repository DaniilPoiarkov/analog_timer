using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.DigitPatterns.Implementations;

internal class ThreePattern : IDigitPattern
{
    public List<string> Pattern => new()
    {
        //"████████",
        //"       █",
        //"       █",
        //"████████",
        //"       █",
        //"       █",
        //"████████",
        "███████",
        "      █",
        "███████",
        "      █",
        "███████",
    };
}
