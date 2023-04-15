namespace AnalogTimer.Prompts.Implementations;

public class ResetPrompt : PromptBase
{
    public override string Name => "Reset";

    public override string Instruction => "Write \'reset\' to stop timer and set all values to zero";

    public override async Task Proceed(string? input, AnalogTimer.Implementations.AnalogTimer timer)
    {
        await timer.Stop();
        timer.ResetState();
    }
}
