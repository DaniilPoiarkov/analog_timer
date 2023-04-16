namespace AnalogTimer.Prompts.Implementations;

public class ChangeSpeedPrompt : PromptBase
{
    public override string Name => "Speed";

    public override string Instruction => "Write \'speed x\' where \'x\' represents ticks per second.";

    public override Task Proceed(string? input, AnalogTimer.Implementations.AnalogTimer timer)
    {
        var values = SplitInput(input ?? string.Empty).ToList();

        ValidateInput(values);

        var ticksPerSecond = int.Parse(values[1]);

        timer.ChangeTicksPerSecond(ticksPerSecond);

        return Task.CompletedTask;
    }
}
