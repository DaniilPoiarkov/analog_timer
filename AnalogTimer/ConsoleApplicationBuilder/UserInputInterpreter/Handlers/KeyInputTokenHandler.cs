using ConsoleApplicationBuilder.Models.Enums;

namespace ConsoleApplicationBuilder.UserInputInterpreter.Handlers;

internal class KeyInputTokenHandler : TokenHandlerBase
{
    internal override InputToken? Handle(string token, int index, List<string> splitted)
    {
        if (!StartWithSpecialSymbol(token) && index == 0)
        {
            return new InputToken(token, TokenType.Key);
        }

        return base.Handle(token, index, splitted);
    }
}
