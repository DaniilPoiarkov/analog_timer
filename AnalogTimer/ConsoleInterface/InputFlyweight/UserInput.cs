using ConsoleInterface.Models.Enums;
using ConsoleInterface.Models.Exceptions;

namespace ConsoleInterface.InputFlyweight;

public class UserInput
{
    public IEnumerable<InputToken> Tokens { get; init; }

    public UserInput(string input)
    {
        var splitted = input.Trim()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(v => v.ToLower())
            .ToList();

        var tokens = new List<InputToken>();

        for(int i = 0; i < splitted.Count; i++)
        {
            var token = splitted[i];

            if (token is null)
            {
                continue;
            }

            if (NotStartWithSpecialSymbol(token))
            {
                tokens.Add(new InputToken(token));
                continue;
            }

            if (token.StartsWith('\'') || token.StartsWith("\""))
            {
                var closure = token.StartsWith('\'') ? '\'' : '\"';
                var indexToAdd = 1;

                var multiToken = new List<string>();

                while (token.EndsWith(closure))
                {
                    multiToken.Add(token);

                    if (splitted.Count == tokens.Count + multiToken.Count)
                    {
                        throw new InvalidInputException(InputExceptionType.ClosureTag);
                    }

                    token = splitted[i + indexToAdd];
                    indexToAdd++;
                }

                splitted.RemoveRange(i, multiToken.Count);
            }

            if (i == splitted.Count)
            {
                throw new ArgumentException("Invalid input", input);
            }

            tokens.Add(new InputToken($"{token} {splitted[i + 1]}"));
            splitted.RemoveAt(i + 1);
        }

        Tokens = tokens;
    }

    private static bool NotStartWithSpecialSymbol(string token)
    {
        return !token.StartsWith('-') && !token.StartsWith('\'') || !token.StartsWith('\"');
    }

    public override string ToString()
    {
        return string.Join(" ", Tokens.Select(t => t.Value));
    }
}
