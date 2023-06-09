using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.DigitPatterns.Implementations;

internal class FiveDrawer : IDigitPattern
{
    public List<string> Pattern => new()
    {
        "████████",
        "█       ",
        "█       ",
        "████████",
        "       █",
        "       █",
        "████████",
    };
}
