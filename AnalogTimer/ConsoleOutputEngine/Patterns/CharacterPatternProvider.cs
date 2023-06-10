using ConsoleOutputEngine.Contracts;
using ConsoleOutputEngine.Patterns.DigitPatterns.Implementations;
using ConsoleOutputEngine.Patterns.LetterPatterns.Implementations;
using ConsoleOutputEngine.Patterns.SpecialCharacterPatterns;

namespace ConsoleOutputEngine.Patterns;

internal class CharacterPatternProvider
{
    public static ICharacterPattern Get(char letter)
    {
        return letter switch
        {
            'A' => new LetterA(),
            'B' => new LetterB(),
            'C' => new LetterC(),
            'D' => new LetterD(),
            'E' => new LetterE(),
            'F' => new LetterF(),
            'G' => new LetterG(),
            'H' => new LetterH(),
            'I' => new LetterI(),
            'J' => new LetterJ(),
            'K' => new LetterK(),
            'L' => new LetterL(),
            'M' => new LetterM(),
            'N' => new LetterN(),
            'O' => new LetterO(),
            'P' => new LetterP(),
            'Q' => new LetterQ(),
            'R' => new LetterR(),
            'S' => new LetterS(),
            'T' => new LetterT(),
            'U' => new LetterU(),
            'V' => new LetterV(),
            'W' => new LetterW(),
            'X' => new LetterX(),
            'Y' => new LetterY(),
            'Z' => new LetterZ(),
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
            ',' => new CommaPattern(),
            _ => new EmptyLetter(),
        };
    }
}
