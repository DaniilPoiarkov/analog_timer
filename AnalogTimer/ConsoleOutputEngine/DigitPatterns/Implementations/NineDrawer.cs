using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.DigitPatterns.Implementations;

internal class NineDrawer : IDigitPattern
{
    public List<string> Pattern => new()
    {
        "████████",
        "█      █",
        "█      █",
        "████████",
        "       █",
        "       █",
        "████████",
    };
}
