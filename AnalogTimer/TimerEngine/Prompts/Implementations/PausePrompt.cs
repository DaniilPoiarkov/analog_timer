using AnalogTimer.Contracts;
namespace AnalogTimer.Prompts.Implementations;

public class PausePrompt : PromptBase
{
    public override string Name => "pause";

    public override string Instruction => "White \'pause\' or \'-p\' to pause a timer.";

    public override string Shortcut => "-p";

    public override async Task Proceed(string input, IAnalogTimer timer)
    {
        await timer.Stop();
    }
}
