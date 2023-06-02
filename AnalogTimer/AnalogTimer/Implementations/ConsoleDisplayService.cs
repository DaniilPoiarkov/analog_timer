using AnalogTimer.Contracts;
using AnalogTimer.DigitDrawers;
using AnalogTimer.DisplayHandlers.ConsoleHandlers;
using AnalogTimer.Helpers;
using AnalogTimer.Models;
using AnalogTimer.Models.Enums;
using TimerEngine.Models.TimerEventArgs;

namespace AnalogTimer.Implementations;

public class ConsoleDisplayService : IDisplayService
{
    private readonly ITimerTemplate _timerTemplate;

    private TimerState? _snapshot;

    private readonly IDisplayHandler _handler;


    private const int _dotsBetweenHourAndMinute = 23;

    private const int _dotsBetweenMinuteAndSecond = 49;

    private const int _dotsBetweenSecondsAndMilliseconds = 75;

    private const int _position = 91;

    private const int _maxPositionLeft = 104;

    private const int _maxPositionTop = 29;

    private const int _space = 23;

    private const int _startPositionTop = 25;

    private const int _startPositionLeft = 0;


    private static int PositionTop = _startPositionTop;

    private static int PositionLeft = _startPositionLeft;


    public ConsoleDisplayService(ITimerTemplate timerTemplate)
    {
        _timerTemplate = timerTemplate;
        _handler = MatrixDisplayHandler.Instance;

        MillisecondDisplayHelper.OutputHandler += (_, digit) =>
        {
            MatrixDisplayHandler.Instance
                .DisplayPattern(DigitDrawerProvider.GetDrawer(digit).Pattern, _position);
            UIHelper.SetCursor();
        };

        PrintDots(_dotsBetweenHourAndMinute);
        PrintDots(_dotsBetweenMinuteAndSecond);
        PrintDots(_dotsBetweenSecondsAndMilliseconds);

        MillisecondDisplayHelper.DisplayZero();
        DisplayTick(new());
    }

    public void DisplayTick(TimerState state)
    {
        if (state.Hours != _snapshot?.Hours)
            _handler.Update(state.Hours, TimerValue.Hour);

        if (state.Minutes != _snapshot?.Minutes)
            _handler.Update(state.Minutes, TimerValue.Minute);

        if (state.Seconds != _snapshot?.Seconds)
            _handler.Update(state.Seconds, TimerValue.Second);

        if (state.Milliseconds != _snapshot?.Milliseconds)
            _handler.Update(state.Milliseconds, TimerValue.Millisecond);

        _snapshot = new(state.Hours, state.Minutes, state.Seconds, state.Milliseconds);
    }

    private void PrintDots(int position)
    {
        Console.CursorTop = 2;
        Console.CursorLeft = position;

        Console.WriteLine(_timerTemplate.Pattern);

        Console.CursorTop = 5;
        Console.CursorLeft = position;

        Console.WriteLine(_timerTemplate.Pattern);
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
