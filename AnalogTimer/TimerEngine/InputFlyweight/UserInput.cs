using AnalogTimer.Models.Enums;

namespace AnalogTimer.InputFlyweight;

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

            if (!token.StartsWith('-'))
            {
                tokens.Add(new InputToken(token));
                continue;
            }

            if (i == splitted.Count)
            {
                throw new ArgumentException("Invalid input", input);
            }

            tokens.Add(new InputToken($"{token[1..]} {splitted[i + 1]}"));
            splitted.RemoveAt(i + 1);
        }

        Tokens = tokens;
    }

    public override string ToString()
    {
        return string.Join(" ", Tokens.Select(t => t.Type == TokenType.Flag
            ? $"-{t.Value}"
            : t.Value));
    }
}
