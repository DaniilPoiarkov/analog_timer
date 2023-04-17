using AnalogTimer.Contracts;

namespace AnalogTimer.Prompts.Implementations;

public class ResetPrompt : PromptBase
{
    public override string Name => "Reset";

    public override string Instruction => "Write \'reset\' to stop timer and set all values to zero";

    public override Task Proceed(string? input, IAnalogTimer timer)
    {
        timer.ResetState();
        return Task.CompletedTask;
    }
}
