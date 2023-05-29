using ConsoleInterface.Models.Enums;

namespace ConsoleInterface.UserInputInterpreter;

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
