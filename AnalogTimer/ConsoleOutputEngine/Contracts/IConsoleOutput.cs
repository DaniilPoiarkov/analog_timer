using ConsoleOutputEngine.Implementations;

namespace ConsoleOutputEngine.Contracts;

public interface IConsoleOutput
{
    int PositionLeft { get; set; }

    void Out(string value);

    void Out(string value, IConsoleOutputFormatter formatter);

    void Out(int value);

    int GetLength(object value);

    static IConsoleOutput Create() => new ConsoleOutput();
}
