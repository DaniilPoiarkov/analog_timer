﻿using AnalogTimer.Contracts;
using AnalogTimer.Prompts;

namespace TimerEngine.Prompts.Implementations;

public class CloseTimerPrompt : AnalogTimerPromptBase
{
    public override string Name => "close";

    public override string Instruction => "Write \'close\' to close a timer.";

    public override string Shortcut => Name;

    public override Task Proceed(string input, IAnalogTimer timer)
    {
        Console.CursorTop += GetType().Assembly
            .GetTypes()
            .Where(t => t.IsAssignableTo(typeof(AnalogTimerPromptBase))
                && !t.IsAbstract
                && !t.IsInterface)
            .Count() + 5;

        Environment.Exit(0);

        return Task.CompletedTask;
    }
}
