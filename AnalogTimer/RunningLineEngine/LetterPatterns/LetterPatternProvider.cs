using RunningLineEngine.Contracts;
using RunningLineEngine.LetterPatterns.Implementations;

namespace RunningLineEngine.LetterPatterns;

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
            _ => new EmptyLetter(),
        };
    }
}
