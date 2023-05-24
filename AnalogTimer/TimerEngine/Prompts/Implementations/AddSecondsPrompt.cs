using AnalogTimer.Contracts;
using AnalogTimer.Prompts;

namespace TimerEngine.Prompts.Implementations;

public class AddSecondsPrompt : PromptBase
{
    public override string Name => "seconds";

    public override string Instruction => "Write \'seconds x\' or \'-s x\' where \'x\' is amount of seconds which you want to add.";

    public override string Shortcut => "-s";

    public override Task Proceed(string input, IAnalogTimer timer)
    {
        var values = ParseAndValidateInput(input);

        var seconds = int.Parse(values[1]);

        timer.AddSeconds(seconds);

        return Task.CompletedTask;
    }
}
