using AnalogTimer.Contracts;
using AnalogTimer.DigitDrawers;
using AnalogTimer.Models;
using AnalogTimer.Models.Enums;

namespace AnalogTimer.Implementations;

public class DisplayService : IDisplayService
{
    private readonly ITimerTemplate _timerTemplate;

    private TimerState? _snapshot;


    private const int _space = 13;

    private const int _zero = 0;

    private const int _dotsBetweenHourAndMinute = 23;

    private const int _dotsBetweenMinuteAndSecond = 49;

    private const int _dotsBetweenSecondsAndMilliseconds = 75;

    private const int _startPositionForHour = 0;

    private const int _startPositionForMinute = 26;

    private const int _startPositionForSecond = 52;

    private const int _startPositionForMillisecond = 78;

    public DisplayService(ITimerTemplate timerTemplate)
    {
        _timerTemplate = timerTemplate;

        PrintDots(_dotsBetweenHourAndMinute);
        PrintDots(_dotsBetweenMinuteAndSecond);
        PrintDots(_dotsBetweenSecondsAndMilliseconds);

        Display(new());
    }

    public void Display(TimerState state)
    {
        lock (this)
        {
            if (state.Hours != _snapshot?.Hours)
                Update(state.Hours, TimerValue.Hour);

            if (state.Minutes != _snapshot?.Minutes)
                Update(state.Minutes, TimerValue.Minute);

            if (state.Seconds != _snapshot?.Seconds)
                Update(state.Seconds, TimerValue.Second);

            Update(state.Milliseconds, TimerValue.Millisecond);
        }

        _snapshot = new(state.Hours, state.Minutes, state.Seconds);
    }

    private void Update(int digit, TimerValue value)
    {
        var asString = digit.ToString();

        if (string.IsNullOrEmpty(asString) || asString.Length > 2)
        {
            throw new ArgumentException($"Invalid timer digit {digit}", nameof(digit));
        }

        var positionLeft = value switch
        {
            TimerValue.Hour => _startPositionForHour,
            TimerValue.Minute => _startPositionForMinute,
            TimerValue.Second => _startPositionForSecond,
            TimerValue.Millisecond => _startPositionForMillisecond,
            _ => throw new ArgumentOutOfRangeException(nameof(value), "No such timer value"),
        };

        var values = ParseValues(asString);

        foreach (var num in values)
        {
            var drawer = DigitDrawerProvider.GetDrawer(num);
            drawer.Draw(positionLeft, _timerTemplate);

            positionLeft += _space;
        }
    }

    private static IEnumerable<int> ParseValues(string asString)
    {
        if (asString.Length >= 2)
        {
            return asString.Select(v => int.Parse(v.ToString()));
        }

        return new[] { _zero, int.Parse(asString) };
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
