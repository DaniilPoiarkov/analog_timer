using ConsoleOutputEngine.Contracts;
using ConsoleOutputEngine.DigitPatterns;
using ConsoleOutputEngine.Helpers;
using ConsoleOutputEngine.LetterPatterns;

namespace ConsoleOutputEngine.Implementations;

internal class ConsoleOutput : IConsoleOutput
{
    private readonly IMatrixDisplay _display = IMatrixDisplay.Instance;

    public int PositionLeft { get; set; }

    public void Out(string value)
    {
        var pattern = value.ToUpper()
            .Select(LetterPatternProvider.Get)
            .Select(p => p.Pattern)
            .ToAggregateModel();

        _display.Display(pattern, PositionLeft);
    }

    public void Out(int value)
    {
        var pattern = value.ToString()
            .Select(v => int.Parse(v.ToString()))
            .Select(DigitPatternProvider.Get)
            .Select(p => p.Pattern)
            .ToAggregateModel();

        _display.Display(pattern, PositionLeft);
    }
}
