﻿using AnalogTimer.Contracts;
using AnalogTimer.InputFlyweight;
using AnalogTimer.Prompts.ShortcutFlags.StartPromptFlags;

namespace AnalogTimer.Prompts.Implementations;

public class StartPrompt : PromptBase
{
    public override string Instruction => "Write \'start\' to start timer.\n\t" +
        "Flags: \'-h\', \'-m\', \'-s\' allows you to add hours, minutes and seconds accordingly.\n\t\t" +
        "Usage with positive number which represents amount of specific value.";

    public override string Name => "start";

    public override string Shortcut => Name;

    private readonly List<IShortcutFlag> _shortcutFlags;

    public StartPrompt()
    {
        _shortcutFlags = new List<IShortcutFlag>()
        {
            new StartSecondsFlag(),
            new StartMinutesFlag(),
            new StartHoursFlag(),
        };
    }

    public override async Task Proceed(string input, IAnalogTimer timer)
    {
        var userInput = new UserInput(input);

        if (userInput.Tokens.Count() == 1)
        {
            timer.Start();
            return;
        }

        var flags = GenerateFlags(userInput, _shortcutFlags)
            .ToList();

        timer.ResetState();

        var tasks = new List<Task>(flags.Count);

        flags.ForEach(f =>
        {
            var handler = _shortcutFlags.First(s => s.Shortcut.Equals(f.Flag));
            tasks.Add(handler.Handle(f.Value, timer));
        });

        await Task.WhenAll(tasks);

        timer.Start();
    }
}
