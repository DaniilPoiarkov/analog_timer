using ConsoleOutputEngine.Implementations;

namespace ConsoleOutputEngine.Contracts;

public interface IConsoleOutput
{
    int PositionLeft { get; set; }

    void Out(IEnumerable<List<string>> values);

    void Out(List<string> values);

    static IConsoleOutput Create() => new ConsoleOutput();
}
