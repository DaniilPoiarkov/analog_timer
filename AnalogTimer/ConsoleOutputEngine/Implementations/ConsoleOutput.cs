using ConsoleOutputEngine.Contracts;
using ConsoleOutputEngine.Helpers;
using ConsoleOutputEngine.Patterns;

namespace ConsoleOutputEngine.Implementations;

internal class ConsoleOutput : IConsoleOutput
{
    private readonly IMatrixDisplay _display = IMatrixDisplay.Instance;

    public int PositionLeft { get; set; }

    private string CachedString { get; set; } = string.Empty;

    private List<string> CachedPattern { get; set; } = new();

    public int GetLength(object value)
    {
        var asString = value.ToString()?.ToUpper();

        if (string.IsNullOrEmpty(asString))
        {
            return 0;
        }

        var patterns = asString.Select(CharacterPatternProvider.Get)
            .Select(p => p.Pattern)
            .ToAggregateModel();

        CachedPattern = patterns;
        CachedString = asString;

        return CachedPattern.First().Length;
    }

    public void Out(string value, IConsoleOutputFormatter formatter)
    {
        if (formatter is null)
        {
            throw new ArgumentNullException(nameof(formatter));
        }

        var normilized = value.ToUpper();

        if (!normilized.Equals(CachedString))
        {
            CachedString = normilized;
            CachedPattern = normilized
                .Select(CharacterPatternProvider.Get)
                .Select(p => p.Pattern)
                .ToAggregateModel();
        }

        var formatted = formatter.Format(CachedPattern).ToList();
        _display.Display(formatted, PositionLeft);
    }

    public void Out(string value) =>
        Out(value, new DefaultConsoleOutputFormatter());

    public void Out(int value) =>
        Out(value.ToString());
}
