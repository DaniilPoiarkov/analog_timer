using RunningLineEngine.Contracts;

namespace RunningLineEngine.Prompts.Implementations;

public class RunPrompt : RunningLinePromptBase
{
    public override string Name => "run";

    public override string Instruction => "Write \'run x\' where\'x\' is a sentence you want to display";

    public override string Shortcut => "-r";

    public override async Task Proceed(string input, IRunningLine entity)
    {
        var args = ParseAndValidateInput(input);
        await entity.Run(args[1]);
    }
}
