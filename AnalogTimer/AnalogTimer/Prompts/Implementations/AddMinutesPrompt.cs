using AnalogTimer.Contracts;

namespace AnalogTimer.Prompts.Implementations;

public class AddMinutesPrompt : PromptBase
{
    public override string Name => "minutes";

    public override string Instruction => "Write \'minutes x\' or \'-m x\' where \'x\' is amount of minutes which you want to add";

    public override string Shortcut => "-m";

    public override Task Proceed(string input, IAnalogTimer timer)
    {
        var values = ParseAndValidateInput(input);

        var minutes = int.Parse(values[1]);

        timer.AddMinutes(minutes);

        return Task.CompletedTask;
    }
}
