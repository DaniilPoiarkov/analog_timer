namespace AnalogTimer.Contracts;

public interface IShortcutFlag
{
    string Shortcut { get; }

    Task Handle(string value, IAnalogTimer timer);
}
