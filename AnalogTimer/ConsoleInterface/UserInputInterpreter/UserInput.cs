using ConsoleInterface.Models.Enums;
using ConsoleInterface.Models.Exceptions;

namespace ConsoleInterface.UserInputInterpreter;

public class UserInput
{
    public IEnumerable<InputToken> Tokens { get; init; }

    public UserInput(string input)
    {
        var splitted = input.Trim()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        Tokens = LexAnalysis(splitted);
    }

    private static IEnumerable<InputToken> LexAnalysis(List<string> splitted)
    {
        var tokens = new List<InputToken>(splitted.Count);

        for (int i = 0; i < splitted.Count; i++)
        {
            var token = splitted[i];

            if (!StartWithSpecialSymbol(token) && i == 0)
            {
                tokens.Add(new InputToken(token, TokenType.Key));
                continue;
            }

            if (!StartWithSpecialSymbol(token))
            {
                tokens.Add(new InputToken(token, TokenType.String));
                continue;
            }

            if (token.StartsWith('-'))
            {
                if (i + 1 < splitted.Count)
                {
                    var nextToken = splitted[i + 1];

                    if (!StartWithSpecialSymbol(nextToken))
                    {
                        tokens.Add(new InputToken($"{token} {nextToken}", TokenType.Flag));
                        continue;
                    }
                }

                tokens.Add(new InputToken(token, TokenType.Key));
                continue;
            }

            if (HasOpenTag(token, out var closure))
            {
                var indexToAdd = 1;
                var multiToken = new List<string>();

                while (!token.EndsWith(closure))
                {
                    multiToken.Add(token);

                    if (splitted.Count == tokens.Count + multiToken.Count)
                    {
                        var exceptionInfo = new InputExceptionInfo()
                        {
                            Closure = closure
                        };

                        throw new InvalidInputException(InputExceptionType.ClosureTag, exceptionInfo);
                    }

                    token = splitted[i + indexToAdd];
                    indexToAdd++;
                }

                multiToken.Add(token);
                splitted.RemoveRange(i, multiToken.Count);

                tokens.Add(new InputToken(string.Join(' ', multiToken), TokenType.Sentence));
                continue;
            }

            throw new LexException(i);
        }

        return tokens;
    }

    private static bool HasOpenTag(string token, out char closure)
    {
        closure = new char();
        var hasOpenFlag = token.StartsWith('\'') || token.StartsWith("\"");

        if (hasOpenFlag)
        {
            closure = token.StartsWith('\'') ? '\'' : '\"';
        }

        return hasOpenFlag;
    }

    private static bool StartWithSpecialSymbol(string token)
    {
        return token.StartsWith('-') || token.StartsWith('\'') || token.StartsWith('\"');
    }

    public override string ToString()
    {
        return string.Join(" ", Tokens.Select(t => t.Value));
    }
}
