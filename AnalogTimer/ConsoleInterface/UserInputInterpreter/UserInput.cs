using ConsoleInterface.Models.Enums;
using ConsoleInterface.Models.Exceptions;
using ConsoleInterface.UserInputInterpreter.Handlers;

namespace ConsoleInterface.UserInputInterpreter;

public class UserInput
{
    public IEnumerable<InputToken> Tokens { get; init; }

    private readonly TokenHandlerBase _rootHandler;

    public UserInput(string input)
    {
        var splitted = input.Trim()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        _rootHandler = new();
        _rootHandler.Add(new KeyInputTokenHandler());
        _rootHandler.Add(new StringInputTokenHandler());
        _rootHandler.Add(new FlagOrKeyInputTokenHandler());

        Tokens = LexAnalysis(splitted);
    }

    private IEnumerable<InputToken> LexAnalysis(List<string> splitted)
    {
        var tokens = new List<InputToken>(splitted.Count);

        for (int i = 0; i < splitted.Count; i++)
        {
            var token = splitted[i];

            var inputToken = _rootHandler.Handle(token, i, splitted);

            if (inputToken is not null)
            {
                tokens.Add(inputToken);
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

    public override string ToString()
    {
        return string.Join(" ", Tokens.Select(t => t.Value));
    }
}
