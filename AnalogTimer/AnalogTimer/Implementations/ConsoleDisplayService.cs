using AnalogTimer.Contracts;
using AnalogTimer.Helpers;
using AnalogTimer.Models;
using AnalogTimer.Models.Enums;
using TimerEngine.DisplayHandlers.ConsoleHandlers;

namespace AnalogTimer.Implementations;

public class ConsoleDisplayService : IDisplayService
{
    private readonly ITimerTemplate _timerTemplate;

    private TimerState? _snapshot;

    private readonly IDisplayHandler _handler;


    private const int _dotsBetweenHourAndMinute = 23;

    private const int _dotsBetweenMinuteAndSecond = 49;

    private const int _dotsBetweenSecondsAndMilliseconds = 75;

    public ConsoleDisplayService(ITimerTemplate timerTemplate)
    {
        _timerTemplate = timerTemplate;
        _handler = MatrixDisplayHandler.Instance;

        PrintDots(_dotsBetweenHourAndMinute);
        PrintDots(_dotsBetweenMinuteAndSecond);
        PrintDots(_dotsBetweenSecondsAndMilliseconds);

        MillisecondDisplayHelper.DisplayZero();
        Display(new());
    }

    public void Display(TimerState state)
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
}
