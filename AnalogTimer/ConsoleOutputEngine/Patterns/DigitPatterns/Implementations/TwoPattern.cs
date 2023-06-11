using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.DigitPatterns.Implementations;

internal class TwoPattern : IDigitPattern
{
    public List<string> Pattern => new()
    {
        "████████",
        "       █",
        "       █",
        "████████",
        "█       ",
        "█       ",
        "████████",
        //" ██████ ",
        //"       █",
        //"  █████ ",
        //" █      ",
        //" ██████ ",
    };
}
