﻿using AnalogTimer.Contracts;
using AnalogTimer.Prompts;

namespace TimerEngine.Prompts.Implementations;

public class AddHoursPrompt : AnalogTimerPromptBase
{
    public override string Name => "hours";

    public override string Instruction => "Write \'hours x\' or \'-h x\' where \'x\' is amount of hours which you want to add.";

    public override string Shortcut => "-h";

    public override Task Proceed(string input, IAnalogTimer timer)
    {
        var values = ParseAndValidateInput(input);

        var hours = int.Parse(values[1]);

        timer.AddHours(hours);

        return Task.CompletedTask;
    }
}
