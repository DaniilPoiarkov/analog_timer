namespace AnalogTimer.Contracts;

public interface IAnalogTimerShortcutFlag
{
    string Shortcut { get; }

    Task Handle(string value, IAnalogTimer timer);
}
