using AnalogTimer.Contracts;

namespace AnalogTimer.Prompts.Implementations;

public class ResetPrompt : PromptBase
{
    public override string Name => "reset";

    public override string Instruction => "Write \'reset\' or \'-r\' to stop timer and set all values to zero.";

    public override string Shortcut => "-r";

    public override Task Proceed(string? input, IAnalogTimer timer)
    {
        timer.ResetState();
        return Task.CompletedTask;
    }
}
