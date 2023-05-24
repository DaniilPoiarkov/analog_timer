using AnalogTimer.Contracts;

namespace TimerEngine.Prompts.ShortcutFlags.StartPromptFlags;

public class StartHoursFlag : IShortcutFlag
{
    public string Shortcut => "h";

    public Task Handle(string value, IAnalogTimer timer)
    {
        var hours = int.Parse(value);
        timer.AddHours(hours);
        return Task.CompletedTask;
    }
}
