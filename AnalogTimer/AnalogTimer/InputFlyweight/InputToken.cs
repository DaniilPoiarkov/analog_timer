using AnalogTimer.Models.Enums;

namespace AnalogTimer.InputFlyweight;

public class InputToken
{
    public string Value { get; init; }

    public TokenType Type { get; init; }

    public InputToken(string value)
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
