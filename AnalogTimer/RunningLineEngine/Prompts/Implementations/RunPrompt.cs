using RunningLineEngine.Contracts;

namespace RunningLineEngine.Prompts.Implementations;

public class RunPrompt : RunningLinePromptBase
{
    public override string Name => "run";

    public override string Instruction => "Write \'run x\' or \'-r x\' where\'x\' is a sentence you want to display.";

    public override string Shortcut => "-r";

    public override Task Proceed(string input, IRunningLine entity)
    {
        var args = ParseAndValidateInput(input);

        entity.Set(args[1]);
        entity.Start();

        return Task.CompletedTask;
    }
}
