﻿using AnalogTimer.Contracts;
using AnalogTimer.Models.Enums;

namespace AnalogTimer.DisplayHandlers;

public abstract class DisplayHandlerBase : IDisplayHandler
{
    protected const int _space = 13;

    private const int _zero = 0;

    private const int _startPositionForHour = 0;

    private const int _startPositionForMinute = 26;

    private const int _startPositionForSecond = 52;

    private const int _startPositionForMillisecond = 78;

    protected const char _empty = ' ';

    public abstract void Update(int digit, TimerValue value);

    protected static IEnumerable<int> ParseValues(string asString)
    {
        if (asString.Length >= 2)
        {
            return asString.Select(v => int.Parse(v.ToString()));
        }

        return new[] { _zero, int.Parse(asString) };
    }

    protected static int GetPosition(TimerValue value)
    {
        return value switch
        {
            TimerValue.Hour => _startPositionForHour,
            TimerValue.Minute => _startPositionForMinute,
            TimerValue.Second => _startPositionForSecond,
            TimerValue.Millisecond => _startPositionForMillisecond,
            _ => throw new ArgumentOutOfRangeException(nameof(value), "No such timer value"),
        };
    }

    protected static IEnumerable<int> TransformToEnumerable(int digit, TimerValue value)
    {
        var asString = digit.ToString();

        if (string.IsNullOrEmpty(asString) || asString.Length > 2)
        {
            throw new ArgumentException($"Invalid timer digit {digit}", nameof(digit));
        }

        var values = ParseValues(asString)
            .ToList();

        if (value == TimerValue.Millisecond)
        {
            //values[0] = values[0] switch
            //{
            //    <= 3 => 0,
            //    <= 7 => 3,
            //    _ => 7,
            //};

            values[1] = values[1] switch
            {
                <= 3 => 0,
                <= 7 => 3,
                _ => 7,
            };
        }

        return values;
    }
}
