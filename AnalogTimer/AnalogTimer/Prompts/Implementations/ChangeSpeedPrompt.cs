using AnalogTimer.Contracts;

namespace AnalogTimer.Prompts.Implementations;

public class ChangeSpeedPrompt : PromptBase
{
    public override string Name => "speed";

    public override string Instruction => "Write \'speed x\' where \'x\' represents ticks per second.";

    public override Task Proceed(string? input, IAnalogTimer timer)
    {
        var values = ParseAndValidateInput(input ?? string.Empty);

        var ticksPerSecond = int.Parse(values[1]);

        timer.ChangeTicksPerSecond(ticksPerSecond);

        return Task.CompletedTask;
    }
}
