﻿using ConsoleApplicationBuilder.Models.Enums;

namespace ConsoleApplicationBuilder.UserInputInterpreter.Handlers;

internal class StringInputTokenHandler : TokenHandlerBase
{
    internal override InputToken? Handle(string token, int index, List<string> splitted)
    {
        if (!StartWithSpecialSymbol(token))
        {
            return new InputToken(token, TokenType.String);
        }

        return base.Handle(token, index, splitted);
    }
}
