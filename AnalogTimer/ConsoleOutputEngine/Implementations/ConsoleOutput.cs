using ConsoleOutputEngine.Contracts;
using ConsoleOutputEngine.Helpers;
using ConsoleOutputEngine.Patterns;

namespace ConsoleOutputEngine.Implementations;

internal class ConsoleOutput : IConsoleOutput
{
    private readonly IMatrixDisplay _display = IMatrixDisplay.Instance;

    public int PositionLeft { get; set; }

    private readonly Dictionary<string, List<string>> _mapper = new();

    public int GetLength(object value)
    {
        var normalized = value.ToString()?.ToUpper();

        if (string.IsNullOrEmpty(normalized))
        {
            return 0;
        }

        var pattern = _mapper.GetValueOrDefault(normalized)
            ?? GetAndSavePattern(normalized);

        return pattern.First().Length;
    }

    public void Out(string value, IConsoleOutputFormatter formatter)
    {
        if (formatter is null)
        {
            throw new ArgumentNullException(nameof(formatter));
        }

        var normalized = value.ToUpper();

        var pattern = _mapper.GetValueOrDefault(normalized)
            ?? GetAndSavePattern(normalized);

        var formatted = formatter.Format(pattern).ToList();
        _display.Display(formatted, PositionLeft);
    }

    public void Out(string value) =>
        Out(value, new DefaultConsoleOutputFormatter());

    public void Out(int value) =>
        Out(value.ToString());


    private List<string> GetAndSavePattern(string normalized)
    {
        List<string> pattern = normalized
            .Select(CharacterPatternProvider.Get)
            .Select(p => p.Pattern)
            .ToAggregateModel();

        _mapper.Add(normalized, pattern);

        return pattern;
    }
}
