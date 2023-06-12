using ConsoleOutputEngine.Contracts;
using ConsoleOutputEngine.Helpers;

namespace ConsoleOutputEngine.Implementations;

internal class ConsoleOutput : IConsoleOutput
{
    private readonly IMatrixDisplay _display = IMatrixDisplay.Instance;

    public int PositionLeft { get; set; }

    public void Out(IEnumerable<List<string>> values) =>
        Out(values.ToAggregateModel());

    public void Out(List<string> values)
    {
        _display.Display(values, PositionLeft);
    }
}
