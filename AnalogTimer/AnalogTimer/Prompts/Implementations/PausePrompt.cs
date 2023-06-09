using AnalogTimer.Contracts;
using ConsoleApplicationBuilder.Contracts;

namespace ConsoleApplicationBuilder.Prompts.Implementations;

public class PausePrompt : IPrompt<IAnalogTimer>
{
    public string Name => "pause";

    public string Shortcut => "-p";

    public string Instruction => "White \'pause\' or \'-p\' to pause.";

    public async Task Proceed(string input, IAnalogTimer entity)
    {
        await entity.Stop();
    }
}
