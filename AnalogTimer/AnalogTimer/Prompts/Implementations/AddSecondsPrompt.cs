namespace AnalogTimer.Prompts.Implementations;

public class AddSecondsPrompt : PromptBase
{
    public override string Name => "Seconds";

    public override string Instruction => "Write \'seconds x\' where \'x\' is amount of seconds which you want to add";

    public override Task Proceed(string? input, AnalogTimer.Implementations.AnalogTimer timer)
    {
        var values = SplitInput(input ?? string.Empty).ToList();

        if(!values.Any() || values.Count != 2)
        {
            throw new Exception("Invalid input");
        }

        var seconds = int.Parse(values[1]);

        timer.AddSeconds(seconds);

        return Task.CompletedTask;
    }
}
