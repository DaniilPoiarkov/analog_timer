using ConsoleInterface.Models.Enums;

namespace ConsoleInterface.InputFlyweight;

public class InputToken
{
    public string Value { get; init; }

    public TokenType Type { get; init; }

    internal InputToken(string value)
    {
        if (value.Contains(' '))
        {
            Type = TokenType.Flag;
        }
        else
        {
            Type = TokenType.String;
        }

        Value = value;
    }
}
