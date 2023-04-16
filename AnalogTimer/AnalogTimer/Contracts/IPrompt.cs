
namespace AnalogTimer.Contracts;

public interface IPrompt
{
    string Name { get; }

    string Instruction { get; }

    Task Proceed(string? input, Implementations.AnalogTimer timer);
}
