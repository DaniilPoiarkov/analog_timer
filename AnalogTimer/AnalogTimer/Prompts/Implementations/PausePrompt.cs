using AnalogTimer.Contracts;
namespace AnalogTimer.Prompts.Implementations;

public class PausePrompt : PromptBase
{
    public override string Name => "Pause";

    public override string Instruction => "White \'pause\' to pause a timer";

    public override async Task Proceed(string? input, IAnalogTimer timer)
    {
        if(string.IsNullOrEmpty(input))
            throw new ArgumentNullException(nameof(input));

        await timer.Stop();
    }
}
