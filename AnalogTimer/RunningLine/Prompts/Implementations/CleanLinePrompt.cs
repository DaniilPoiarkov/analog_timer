using RunningLineEngine.Contracts;

namespace RunningLineEngine.Prompts.Implementations;

public class CleanLinePrompt : RunningLinePromptBase
{
    public override string Name => "clean";

    public override string Instruction => "Write \'clean\' or \'-c\' to clean running line field";

    public override string Shortcut => "-c";

    public override Task Proceed(string input, IRunningLine entity)
    {
        entity.Clean();
        return Task.CompletedTask;
    }
}
