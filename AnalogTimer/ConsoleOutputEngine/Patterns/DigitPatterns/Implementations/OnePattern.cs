using ConsoleOutputEngine.Contracts;

namespace ConsoleOutputEngine.Patterns.DigitPatterns.Implementations;

internal class OnePattern : IDigitPattern
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
