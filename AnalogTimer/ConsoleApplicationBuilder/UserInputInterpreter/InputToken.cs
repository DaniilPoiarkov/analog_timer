using ConsoleApplicationBuilder.Models.Enums;

namespace ConsoleApplicationBuilder.UserInputInterpreter;

public class InputToken
{
    public string Value { get; init; }

    public TokenType Type { get; init; }

    internal InputToken(string value, TokenType type)
    {
        Type = type;
        Value = value;
    }
}
