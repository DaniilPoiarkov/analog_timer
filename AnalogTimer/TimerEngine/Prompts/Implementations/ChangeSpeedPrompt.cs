using AnalogTimer.Contracts;
using AnalogTimer.Prompts;

namespace TimerEngine.Prompts.Implementations;

public class ChangeSpeedPrompt : AnalogTimerPromptBase
{
    public override string Name => "speed";

    public override string Instruction => "Write \'speed x\' where \'x\' represents ticks per second.";

    public override string Shortcut => Name;

    public override Task Proceed(string input, IAnalogTimer timer)
    {
        var values = ParseAndValidateInput(input);

        var ticksPerSecond = int.Parse(values[1]);

        timer.ChangeTicksPerSecond(ticksPerSecond);

        return Task.CompletedTask;
    }
}
