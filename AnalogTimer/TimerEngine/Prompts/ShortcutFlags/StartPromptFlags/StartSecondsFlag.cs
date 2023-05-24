using AnalogTimer.Contracts;

namespace TimerEngine.Prompts.ShortcutFlags.StartPromptFlags;

internal class StartSecondsFlag : IShortcutFlag
{
    public string Shortcut => "s";

    public Task Handle(string value, IAnalogTimer timer)
    {
        var seconds = int.Parse(value);
        timer.AddSeconds(seconds);
        return Task.CompletedTask;
    }
}
