using AnalogTimer.Helpers;
using MatrixDisplayEngine.Contracts;
using MatrixDisplayEngine.Implementations;
using RunningLineEngine.Contracts;

namespace AnalogTimer.RunningLineDisplayHandlers;

internal class DefaultDisplayHandler : ILineDisplay
{
    private readonly IMatrixDisplay _matrixDisplay = MatrixDisplay.Instance;

    private readonly List<string> _cleanWindowPattern;

    public DefaultDisplayHandler()
    {
        _cleanWindowPattern = new List<string>();

        for (int i = 1; i < 6; i++)
        {
            _cleanWindowPattern.Add(new string(' ', Console.BufferWidth));
        }
    }

    public void Display(IEnumerable<List<string>> text, int position)
    {
        _matrixDisplay.Display(_cleanWindowPattern, 1);

        _matrixDisplay.Display(text, position);

        UIHelper.SetCursor();
    }
}
