using ConsoleInterface.InputFlyweight;
using RunningLineEngine.Contracts;

namespace RunningLineEngine.Prompts.Implementations;

public class RunPrompt : RunningLinePromptBase
{
    public override string Name => "run";

    public override string Instruction => "Write \'run x\' or \'-r x\' where\'x\' is a sentence you want to display.";

    public override string Shortcut => "-r";

    public override Task Proceed(string input, IRunningLine entity)
    {
        var userInput = new UserInput(input);

        if(userInput.Tokens.Count() == 1)
        {
            entity.Start();
            return Task.CompletedTask;
        }

        var sentence = string.Join(' ', userInput.Tokens
            .Skip(1)
            .Select(t => t.Value));

        entity.Set(sentence[1..^1]);
        entity.Start();

        return Task.CompletedTask;
    }
}
