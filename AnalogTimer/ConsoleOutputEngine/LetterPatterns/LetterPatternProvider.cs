using ConsoleOutputEngine.Contracts;
using ConsoleOutputEngine.LetterPatterns.Implementations;

namespace ConsoleOutputEngine.LetterPatterns;

internal class LetterPatternProvider
{
    public static ILetterPattern Get(char letter)
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
            _ => new EmptyLetter(),
        };
    }
}
