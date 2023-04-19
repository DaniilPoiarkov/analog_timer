using AnalogTimer.Contracts;

namespace AnalogTimer.Prompts.Implementations;

public class ResumePrompt : PromptBase
{
    public override string Name => "resume";

    public override string Instruction => "Write \'resume\' to resume timer";

    public override Task Proceed(string? input, IAnalogTimer timer)
    {
        timer.Start();
        return Task.CompletedTask;
    }
}
