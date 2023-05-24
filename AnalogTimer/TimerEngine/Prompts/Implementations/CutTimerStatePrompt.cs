﻿using AnalogTimer.Contracts;

namespace AnalogTimer.Prompts.Implementations;

public class CutTimerStatePrompt : PromptBase
{
    public override string Name => "cut";

    public override string Instruction => "Write \'cut\' or \'-c\' when timer is running to print its current state";

    public override string Shortcut => "-c";

    public override Task Proceed(string input, IAnalogTimer timer)
    {
        timer.Cut();
        return Task.CompletedTask;
    }
}
