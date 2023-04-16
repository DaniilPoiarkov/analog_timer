using AnalogTimer.Contracts;

namespace AnalogTimer.Prompts.Implementations;

public class CloseTimerPrompt : PromptBase
{
    public override string Name => "Close";

    public override string Instruction => "Write \'close\' to close a timer";

    public override Task Proceed(string? input, AnalogTimer.Implementations.AnalogTimer timer)
    {
        Console.CursorTop += GetType().Assembly
            .GetTypes()
            .Where(t => t.IsAssignableTo(typeof(IPrompt))
                && !t.IsAbstract
                && !t.IsInterface)
            .Count() + 5;

        Environment.Exit(0);

        return Task.CompletedTask;
    }
}
