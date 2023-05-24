using AnalogTimer.Contracts;

namespace TimerEngine.Prompts.ShortcutFlags.StartPromptFlags;

internal class StartMinutesFlag : IShortcutFlag
{
    public string Shortcut => "m";

    public Task Handle(string value, IAnalogTimer timer)
    {
        var minutes = int.Parse(value);
        timer.AddMinutes(minutes);
        return Task.CompletedTask;
    }
}
