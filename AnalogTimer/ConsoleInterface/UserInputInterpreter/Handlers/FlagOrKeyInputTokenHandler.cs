using ConsoleInterface.Models.Enums;

namespace ConsoleInterface.UserInputInterpreter.Handlers;

internal class FlagOrKeyInputTokenHandler : TokenHandlerBase
{
    internal override InputToken? Handle(string token, int index, List<string> splitted)
    {
        if (!token.StartsWith('-'))
        {
            return base.Handle(token, index, splitted);
        }

        if (index + 1 < splitted.Count)
        {
            var nextToken = splitted[index + 1];

            if (!StartWithSpecialSymbol(nextToken))
            {
                return new InputToken($"{token} {nextToken}", TokenType.Flag);
            }
        }

        return new InputToken(token, TokenType.Key);
    }
}
