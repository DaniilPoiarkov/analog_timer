
namespace AnalogTimer.Contracts;

public interface IAnalogTimerPrompt
{
    string Name { get; }

    string Shortcut { get; }

    string Instruction { get; }

    Task Proceed(string input, IAnalogTimer timer);
}
