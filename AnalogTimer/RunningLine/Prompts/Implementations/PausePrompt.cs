using ConsoleApplicationBuilder.Contracts;
using RunningLineEngine.Contracts;

namespace RunningLine.Prompts.Implementations;

public class PausePrompt : IPrompt<IRunningLine>
{
    public string Name => "pause";

    public string Shortcut => "-p";

    public string Instruction => "White \'pause\' or \'-p\' to pause.";

    public async Task Proceed(string input, IRunningLine entity)
    {
        await entity.Stop();
    }
}
