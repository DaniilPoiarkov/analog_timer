using AnalogTimer.Contracts;

namespace AnalogTimer.Prompts;

public abstract class PromptBase : IPrompt
{
    public abstract string Name { get; }

    public abstract string Instruction { get; }

    public abstract Task Proceed(string input, IAnalogTimer timer);

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
}
