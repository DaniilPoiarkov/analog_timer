using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.DigitPatterns.Implementations;

internal class SixDrawer : IDigitPattern
{
    public List<string> Pattern => new()
    {
        "████████",
        "█       ",
        "█       ",
        "████████",
        "█      █",
        "█      █",
        "████████",
    };
}
