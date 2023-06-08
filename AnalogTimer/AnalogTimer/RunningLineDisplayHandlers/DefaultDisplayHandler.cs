using AnalogTimer.Helpers;
using MatrixDisplayEngine.Contracts;
using RunningLineEngine.Contracts;

namespace AnalogTimer.RunningLineDisplayHandlers;

internal class DefaultDisplayHandler : ILineDisplay
{
    private readonly IMatrixDisplay _matrixDisplay = IMatrixDisplay.Instance;

    private readonly List<string> _cleanWindowPattern;

    public DefaultDisplayHandler()
    {
        _cleanWindowPattern = new List<string>();

        for (int i = 1; i < 6; i++)
        {
            _cleanWindowPattern.Add(new string(' ', Console.BufferWidth));
        }
    }

    public void Clean()
    {
        _matrixDisplay.Display(_cleanWindowPattern, 1);
    }

    public void Display(IEnumerable<string> text, int position)
    {
        Clean();

        _matrixDisplay.Display(text.ToList(), position);

        UIHelper.SetCursor();
    }
}
