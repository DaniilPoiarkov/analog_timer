using AnalogTimer.Models.Enums;
using AnalogTimer.TimerDisplayHandlers;
using ConsoleApplicationBuilder.Helpers;
using ConsoleOutputEngine.Contracts;

namespace AnalogTimer.DisplayHandlers.ConsoleHandlers;

public class MatrixDisplayHandler : DisplayHandlerBase
{
    private readonly IConsoleOutput _output = IConsoleOutput.Create();

    private MatrixDisplayHandler() { }

    private static readonly Lazy<MatrixDisplayHandler> _instance = new(() => new MatrixDisplayHandler());

    public static MatrixDisplayHandler Instance => _instance.Value;


    public override void Update(int digit, TimerValue value)
    {
        _output.PositionLeft = GetPosition(value);

        var text = string.Join(string.Empty, TransformToEnumerable(digit, value));

        _output.Out(text);

        UIHelper.SetCursor();
    }
}
