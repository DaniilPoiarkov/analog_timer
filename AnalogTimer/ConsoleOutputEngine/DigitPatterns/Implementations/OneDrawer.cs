using ConsoleOutputEngine.Contracts;
namespace ConsoleOutputEngine.DigitPatterns.Implementations;

internal class OneDrawer : IDigitPattern
{
    public List<string> Pattern => new()
    {
        "       █",
        "       █",
        "       █",
        "       █",
        "       █",
        "       █",
        "       █",
    };
}
