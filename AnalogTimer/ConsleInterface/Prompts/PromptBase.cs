using ConsoleInterface.InputFlyweight;
using ConsoleInterface.Models.Enums;

namespace ConsoleInterface.Prompts;

public abstract class PromptBase
{
    public abstract string Name { get; }

    public abstract string Instruction { get; }

    public abstract string Shortcut { get; }

    protected static IEnumerable<string> SplitInput(string input) => input
        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .Select(v => v.ToLower());

    protected static void ValidateInput(List<string> values)
    {
        if (!values.Any() || values.Count != 2)
            throw new ArgumentException("Invalid input");
    }

    protected static List<string> ParseAndValidateInput(string input)
    {
        var values = SplitInput(input).ToList();
        ValidateInput(values);
        return values;
    }

    protected static IEnumerable<(string Flag, string Value)> ParseUserInput(UserInput userInput)
    {
        var parsed = userInput.Tokens
            .Where(t => t.Type == TokenType.Flag)
            .Select(t => t.Value
                .Trim()
                .Split(' '));

        if (!parsed.Any())
        {
            throw new InvalidOperationException($"Cannot parse expression \'{userInput}\'. Ensure that you are using only valid shorcuts",
                new Exception($"Tokens ({userInput.Tokens.Count()}): \'{string.Join(' ', userInput.Tokens.Select(t => t.Value))}\'" +
                    $"{Environment.NewLine}" +
                    $"Parsed ({parsed.Count()}): {string.Join(',', parsed.Select(p => string.Join(' ', p)))}"));
        }

        if (parsed.Any(p => p.Length != 2))
        {
            var unexpected = parsed.Where(p => p.Length != 2)
                .Select(p => string.Join(" ", p))
                .Select(v => $"\'-{v}\'");

            throw new InvalidOperationException($"Unexpected value(s) {string.Join(' ', unexpected)}");
        }

        return parsed.Where(v => v.Length == 2)
            .Select(v => (Flag: v[0], Value: v[1]))
            .ToList();
    }

    //protected static void ValidateFlags(IEnumerable<(string Flag, string Value)> flags, IEnumerable<IShortcutFlag> shortcuts)
    //{
    //    if (!flags.All(f => shortcuts.Any(s => s.Shortcut.Equals(f.Flag))))
    //    {
    //        var unexpected = flags.Where(f =>
    //            !shortcuts.Any(s => s.Shortcut.Equals(f.Flag)))
    //            .Select(f => $"-{f.Flag}");

    //        throw new InvalidOperationException($"Unexpected flag(s) {string.Join(", ", unexpected)}");
    //    }
    //}

    //protected static IEnumerable<(string Flag, string Value)> GenerateFlags(UserInput userInput, IEnumerable<IShortcutFlag> shortcuts)
    //{
    //    var flags = ParseUserInput(userInput);
    //    ValidateFlags(flags, shortcuts);
    //    return flags;
    //}
}
