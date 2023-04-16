using AnalogTimer.Contracts;

namespace AnalogTimer.Prompts;

public abstract class PromptBase : IPrompt
{
    public abstract string Name { get; }

    public abstract string Instruction { get; }

    public abstract Task Proceed(string? input, AnalogTimer.Implementations.AnalogTimer timer);

    protected static IEnumerable<string> SplitInput(string input) => input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
}
