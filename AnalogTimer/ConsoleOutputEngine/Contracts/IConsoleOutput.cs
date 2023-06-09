using ConsoleOutputEngine.Implementations;

namespace ConsoleOutputEngine.Contracts;

public interface IConsoleOutput
{
    int PositionLeft { get; set; }

    void Out(string value);

    void Out(int value);

    static IConsoleOutput Create() => new ConsoleOutput();
}
