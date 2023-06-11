using AnalogTimer.Contracts;
using AnalogTimer.Helpers;
using AnalogTimer.Models;
using ConsoleApplicationBuilder.Helpers;
using ConsoleOutputEngine.Contracts;
using TimerEngine.Models.TimerEventArgs;

namespace AnalogTimer.Implementations;

public class ConsoleDisplayService : IDisplayService
{
    private readonly IConsoleOutput _output = IConsoleOutput.Create();

    private readonly object _lock = new();


    private const int _position = 81;

    private const int _maxPositionLeft = 104;

    private const int _maxPositionTop = 29;

    private const int _space = 23;

    private const int _startPositionTop = 25;

    private const int _startPositionLeft = 0;


    private static int PositionTop = _startPositionTop;

    private static int PositionLeft = _startPositionLeft;

    public ConsoleDisplayService()
    {
        MillisecondDisplayHelper.OutputHandler += (_, digit) =>
        {
            PrintValue(digit.ToString(), _position);

            UIHelper.SetCursor();
        };

        MillisecondDisplayHelper.DisplayZero();
        DisplayTick(new());
    }

    private void PrintValue(string value, int position)
    {
        lock (_lock)
        {
            _output.PositionLeft = position;
            _output.Out(value);
        }
    }

    public void DisplayTick(TimerState state)
    {
        PrintValue(state.ToString(), 0);
    }

    public void DisplayUpdated(TimerEventArgs args)
    {
        if (args.State is not null)
            DisplayTick(args.State);
    }

    public void DisplayCut(TimerEventArgs args)
    {
        if (PositionTop >= _maxPositionTop)
        {
            PositionTop = _startPositionTop;
            PositionLeft += _space;
        }

        if (PositionLeft >= _maxPositionLeft)
        {
            PositionTop = _startPositionTop;
            PositionLeft = _startPositionLeft;
        }

        Console.CursorTop = PositionTop;
        Console.CursorLeft = PositionLeft;

        Console.WriteLine($"|{DateTime.UtcNow.ToShortTimeString()} => {args.State}|");
        PositionTop++;
    }
}
