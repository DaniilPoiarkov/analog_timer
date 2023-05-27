using ConsoleInterface.UserInputInterpreter;
using ConsoleInterface.Models.Enums;
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

        var firstToken = userInput.Tokens.First();
        var tokensCount = userInput.Tokens.Count();

        if (tokensCount == 1 && firstToken.Type == TokenType.Key)
        {
            entity.Start();
            return Task.CompletedTask;
        }

        if (firstToken.Type != TokenType.Key)
        {
            throw new Exception("Invalid format. If you want to specify a sentence put it in quotes.");
        }

        var sentence = string.Join(' ', userInput.Tokens
            .Skip(1)
            .Select(t => t.Value));

        entity.Set(sentence[1..^1]);
        entity.Start();

        return Task.CompletedTask;
    }
}
