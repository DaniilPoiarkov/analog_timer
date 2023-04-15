﻿using AnalogTimer.Contracts;
using AnalogTimer.DigitDrawers;
using AnalogTimer.Models;

namespace AnalogTimer.Implementations;

public class DisplayService : IDisplayService
{
    private readonly ITimerTemplate _timerTemplate;

    private const int _space = 13;

    private const int _zero = 0;

    private const int _dotsBetweenHourAndMinute = 23;

    private const int _dotsBetweenMinuteAndSecond = 49;

    private const int _startPositionForHour = 0;

    private const int _startPositionForMinute = 26;

    private const int _startPositionForSecond = 52;

    public DisplayService(ITimerTemplate timerTemplate)
    {
        _timerTemplate = timerTemplate;
    }

    public void Display(TimerState state)
    {
        Update(state.Hours, TimerValue.Hour);
        DeparatorOfTimeValues(_dotsBetweenHourAndMinute);
        Update(state.Minutes, TimerValue.Minute);
        DeparatorOfTimeValues(_dotsBetweenMinuteAndSecond);
        Update(state.Seconds, TimerValue.Second);
    }

    private void Update(int digit, TimerValue value)
    {
        var asString = digit.ToString();

        if (string.IsNullOrEmpty(asString) || asString.Length > 2)
        {
            throw new ArgumentException("Invalid timer digit", nameof(digit));
        }

        var positionLeft = value switch
        {
            TimerValue.Hour => _startPositionForHour,
            TimerValue.Minute => _startPositionForMinute,
            TimerValue.Second => _startPositionForSecond,
            _ => throw new ArgumentOutOfRangeException(nameof(value), "No such timer value"),
        };

        IEnumerable<int> values = Enumerable.Empty<int>();

        if (asString.Length == 2)
        {
            values = asString.Select(v => int.Parse(v.ToString()));
        }
        else
        {
            values = new[] { _zero, int.Parse(asString) };
        }

        foreach(var num in values)
        {
            var drawer = DigitDrawerProvider.GetDrawer(num);
            drawer.Draw(positionLeft, _timerTemplate);

            positionLeft += _space;
        }
    }

    private void DeparatorOfTimeValues(int position)
    {
        Console.CursorTop = 2;
        Console.CursorLeft = position;

        Console.WriteLine(_timerTemplate.Pattern);

        Console.CursorTop = 5;
        Console.CursorLeft = position;

        Console.WriteLine(_timerTemplate.Pattern);
    }
}
