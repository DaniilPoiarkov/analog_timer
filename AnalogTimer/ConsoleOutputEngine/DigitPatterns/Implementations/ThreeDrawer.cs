using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.DigitPatterns.Implementations;

internal class ThreeDrawer : IDigitPattern
{
    public List<string> Pattern => new()
    {
        "████████",
        "       █",
        "       █",
        "████████",
        "       █",
        "       █",
        "████████",
    };
}
