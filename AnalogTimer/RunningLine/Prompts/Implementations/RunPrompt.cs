﻿using RunningLineEngine.Contracts;

namespace RunningLineEngine.Prompts.Implementations;

public class RunPrompt : RunningLinePromptBase
{
    public static event EventHandler<string>? NewSentence;

    public override string Name => "run";

    public override string Instruction => "Write \'run x\' or \'-r x\' where\'x\' is a sentence you want to display.";

    public override string Shortcut => "-r";

    public override Task Proceed(string input, IRunningLine entity)
    {
        var splitted = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (splitted.Length == 1)
        {
            entity.Start();
            return Task.CompletedTask;
        }

        var sentence = string.Join(' ', splitted
            .Skip(1));

        NewSentence?.Invoke(this, sentence);

        entity.Start();

        return Task.CompletedTask;
    }
}
