namespace AnalogTimer.Prompts.Implementations;

public class ResumePrompt : PromptBase
{
    public override string Name => "Resume";

    public override string Instruction => "Write \'resume\' to resume timer";

    public override Task Proceed(string? input, AnalogTimer.Implementations.AnalogTimer timer)
    {
        timer.Start();
        return Task.CompletedTask;
    }
}
