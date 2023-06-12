using AnalogTimer.Contracts;

namespace AnalogTimer.Prompts.ShortcutFlags.StartPromptFlags;

internal class StartSecondsFlag : IAnalogTimerShortcutFlag
{
    public string Shortcut => "-s";

    public Task Handle(string value, IAnalogTimer timer)
    {
        var seconds = int.Parse(value);
        timer.AddSeconds(seconds);
        return Task.CompletedTask;
    }
}
