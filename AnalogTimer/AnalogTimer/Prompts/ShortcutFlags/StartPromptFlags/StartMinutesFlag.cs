using AnalogTimer.Contracts;

namespace AnalogTimer.Prompts.ShortcutFlags.StartPromptFlags;

internal class StartMinutesFlag : IAnalogTimerShortcutFlag
{
    public string Shortcut => "-m";

    public Task Handle(string value, IAnalogTimer timer)
    {
        var minutes = int.Parse(value);
        timer.AddMinutes(minutes);
        return Task.CompletedTask;
    }
}
