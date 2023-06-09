using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.DigitPatterns.Implementations;

internal class SevenDrawer : IDigitPattern
{
    public List<string> Pattern => new()
    {
        "████████",
        "       █",
        "       █",
        "       █",
        "       █",
        "       █",
        "       █",
    };
}
