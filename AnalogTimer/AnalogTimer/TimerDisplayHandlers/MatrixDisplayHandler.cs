using AnalogTimer.DigitDrawers;
using AnalogTimer.Helpers;
using AnalogTimer.Models.Enums;
using ConsoleInterface.Helpers;
using MatrixDisplayEngine.Contracts;

namespace AnalogTimer.DisplayHandlers.ConsoleHandlers;

public class MatrixDisplayHandler : DisplayHandlerBase
{
    private readonly IMatrixDisplay _matrixDisplay = IMatrixDisplay.Instance;

    private MatrixDisplayHandler() { }

    private static readonly Lazy<MatrixDisplayHandler> _instance = new(() => new MatrixDisplayHandler());

    public static MatrixDisplayHandler Instance => _instance.Value;


    public override void Update(int digit, TimerValue value)
    {
        var positionLeft = GetPosition(value);

        var values = TransformToEnumerable(digit, value)
            .Select(DigitDrawerProvider.GetDrawer)
            .Select(d => d.Pattern)
            .AggregateToDisplayModel();

        _matrixDisplay.Display(values, positionLeft);

        UIHelper.SetCursor();
    }
}
