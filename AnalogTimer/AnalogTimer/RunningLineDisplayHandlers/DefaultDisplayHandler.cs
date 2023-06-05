using AnalogTimer.Helpers;
using MatrixDisplayEngine.Contracts;
using MatrixDisplayEngine.Implementations;
using RunningLineEngine.Contracts;

namespace AnalogTimer.RunningLineDisplayHandlers;

internal class DefaultDisplayHandler : ILineDisplay
{
    private readonly IMatrixDisplay _matrixDisplay = MatrixDisplay.Instance;

    public void Display(IEnumerable<List<string>> text, int position)
    {
        for(int i = 1; i < 6; i++)
        {
            Console.CursorTop = 1;
            Console.CursorLeft = position;
            var toClean = Console.BufferWidth - position;
            Console.Write(new string(' ', toClean));
        }

        _matrixDisplay.Display(text, position);

        UIHelper.SetCursor();
    }
}
