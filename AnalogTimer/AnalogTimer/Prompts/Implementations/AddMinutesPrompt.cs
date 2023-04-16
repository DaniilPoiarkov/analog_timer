namespace AnalogTimer.Prompts.Implementations;

public class AddMinutesPrompt : PromptBase
{
    public override string Name => "Minutes";

    public override string Instruction => "Write \'minutes x\' where \'x\' is amount of minutes which you want to add";

    public override Task Proceed(string? input, AnalogTimer.Implementations.AnalogTimer timer)
    {
        var values = SplitInput(input ?? string.Empty).ToList();

        ValidateInput(values);

        var minutes = int.Parse(values[1]);

        timer.AddMinutes(minutes);

        return Task.CompletedTask;
    }
}
