using ConsoleOutputEngine.Contracts;
using ConsoleOutputEngine.Patterns.DigitPatterns.Implementations;

namespace ConsoleOutputEngine.Patterns.DigitPatterns;

internal class DigitPatternProvider
{
    internal static IDigitPattern Get(int digit)
    {
        return digit switch
        {
            0 => new ZeroPattern(),
            1 => new OnePattern(),
            2 => new TwoPattern(),
            3 => new ThreePattern(),
            4 => new FourPattern(),
            5 => new FivePattern(),
            6 => new SixPattern(),
            7 => new SevenPattern(),
            8 => new EightPattern(),
            9 => new NinePattern(),
            _ => throw new ArgumentException("Not a digit", nameof(digit))
        };
    }
}
