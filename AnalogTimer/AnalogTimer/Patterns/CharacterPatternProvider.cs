using AnalogTimer.Patterns.DigitPatterns;
using AnalogTimer.Patterns.SpecialCharacterPatterns;
using ConsoleOutputEngine.Contracts;

namespace AnalogTimer.Patterns;

internal class CharacterPatternProvider
{
    public static ICharacterPattern Get(char letter)
    {
        return letter switch
        {
            '0' => new ZeroPattern(),
            '1' => new OnePattern(),
            '2' => new TwoPattern(),
            '3' => new ThreePattern(),
            '4' => new FourPattern(),
            '5' => new FivePattern(),
            '6' => new SixPattern(),
            '7' => new SevenPattern(),
            '8' => new EightPattern(),
            '9' => new NinePattern(),

            ':' => new DoubleDotsPattern(),

            _ => throw new Exception()
        };
    }
}
