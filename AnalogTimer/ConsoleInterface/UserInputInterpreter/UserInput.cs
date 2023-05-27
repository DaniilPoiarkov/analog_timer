using ConsoleInterface.Models.Enums;
using ConsoleInterface.Models.Exceptions;

namespace ConsoleInterface.UserInputInterpreter;

public class UserInput
{
    public IEnumerable<InputToken> Tokens { get; init; }

    // TODO: Rework as an Interpreter
    public UserInput(string input)
    {
        var splitted = input.Trim()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        Tokens = GetTokens(input, splitted);
    }

    private static IEnumerable<InputToken> GetTokens(string input, List<string> splitted)
    {
        var tokens = new List<InputToken>(splitted.Count);

        for (int i = 0; i < splitted.Count; i++)
        {
            var token = splitted[i];

            if (!StartWithSpecialSymbol(token))
            {
                tokens.Add(new InputToken(token, TokenType.String));
                continue;
            }

            if (token.StartsWith('\'') || token.StartsWith("\""))
            {
                var closure = token.StartsWith('\'') ? '\'' : '\"';
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

            if (i == splitted.Count - 1 && splitted.Count != 1)
            {
                throw new LexException(i);
            }

            if (splitted.Count == 1)
            {
                tokens.Add(new InputToken(token, TokenType.Key));
                break;
            }

            var nextToken = splitted[i + 1];

            if (nextToken.StartsWith('\'') || nextToken.StartsWith('\"'))
            {
                tokens.Add(new InputToken(token, TokenType.Key));
                continue;
            }

            tokens.Add(new InputToken($"{token} {nextToken}", TokenType.Flag));
            splitted.RemoveAt(i + 1);
        }

        return tokens;
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
