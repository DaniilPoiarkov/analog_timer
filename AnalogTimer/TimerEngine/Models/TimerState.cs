using AnalogTimer.Helpers;

namespace AnalogTimer.Models;

public class TimerState
{
    public int Hours { get; private set; }
    public int Minutes { get; private set; }
    public int Seconds { get; private set; }
    public int Milliseconds { get; private set; }
    public bool IsZero { get; private set; }


    private const int _msInSecond = 10;

    private const int _maxValueInMinuteOrHour = 60;

    private const int _zero = 0;


    public TimerState(int hours, int minutes, int seconds, int milliseconds)
    {
        Hours = hours;
        Minutes = minutes;
        Seconds = seconds;
        Milliseconds = milliseconds;

        CheckIsZero();
    }

    public TimerState(int hours, int minutes)
        : this(hours, minutes, _zero, _zero) { }

    public TimerState()
        : this(_zero, _zero) { }

    public void SubtractMilliseconds(int milliseconds)
    {
        Milliseconds -= milliseconds;

        if (Milliseconds < _zero)
        {
            var seconds = _zero;

            var maxValue = Seconds + Minutes * Hours + Minutes * _maxValueInMinuteOrHour + Hours * _maxValueInMinuteOrHour * _maxValueInMinuteOrHour;

            while (Milliseconds < _zero && seconds <= maxValue)
            {
                seconds++;
                Milliseconds += _msInSecond;
            }

            SubtractSeconds(seconds);
        }

        if (Milliseconds < _zero)
        {
            Milliseconds = _zero;
        }

        CheckIsZero();
    }

    public void SubtractSeconds(int seconds)
    {
        Seconds -= seconds;

        if (Seconds < _zero)
        {
            var minutes = _zero;

            var maxValue = Minutes + Hours * _maxValueInMinuteOrHour;

            while (Seconds < _zero && minutes <= maxValue)
            {
                minutes++;
                Seconds += _maxValueInMinuteOrHour;
            }

            SubtractMinutes(minutes);
        }

        if (Seconds < _zero)
        {
            Seconds = _zero;
        }

        CheckIsZero();
    }

    public void SubtractMinutes(int minutes)
    {
        Minutes -= minutes;

        if (Minutes >= _zero)
            return;

        var hours = _zero;

        while (Minutes < _zero && hours <= Hours)
        {
            hours++;
            Minutes += _maxValueInMinuteOrHour;
        }

        SubtractHours(hours);

        if (Minutes < _zero && Hours == _zero)
        {
            Minutes = _zero;
        }

        CheckIsZero();
    }

    public void SubtractHours(int hours)
    {
        Hours -= hours;

        if (Hours < _zero)
        {
            Hours = _zero;
        }

        CheckIsZero();
    }

    private void CheckIsZero()
    {
        IsZero = Milliseconds == _zero
            && Seconds == _zero
            && Minutes == _zero
            && Hours == _zero;
    }

    public void AddMilliseconds(int ms)
    {
        Milliseconds += ms;

        if (IsZero)
            IsZero = false;

        if (Milliseconds < _msInSecond)
            return;

        var seconds = _zero;

        while (Milliseconds >= _msInSecond)
        {
            Milliseconds -= _msInSecond;
            seconds++;
        }

        AddSeconds(seconds);
    }

    public void AddSeconds(int seconds)
    {
        if (seconds < _zero)
            throw new ArgumentException("Seconds cannot be below 0", nameof(seconds));

        Seconds += seconds;

        if (IsZero)
            IsZero = false;

        if (Seconds < _maxValueInMinuteOrHour)
            return;

        var minutes = _zero;

        while (Seconds >= _maxValueInMinuteOrHour)
        {
            minutes++;
            Seconds -= _maxValueInMinuteOrHour;
        }

        AddMinutes(minutes);
    }

    public void AddMinutes(int minutes)
    {
        if (minutes < _zero)
            throw new ArgumentException("Minutes cannot be below 0", nameof(minutes));

        Minutes += minutes;

        if (IsZero)
            IsZero = false;

        if (Minutes < _maxValueInMinuteOrHour)
            return;

        var hours = _zero;

        while (Minutes >= _maxValueInMinuteOrHour)
        {
            hours++;
            Minutes -= _maxValueInMinuteOrHour;
        }

        AddHours(hours);
    }

    public void AddHours(int hours)
    {
        if (hours < _zero)
            throw new ArgumentException("Hours cannot be below 0", nameof(hours));

        Hours += hours;

        if (IsZero)
            IsZero = false;
    }

    public override string ToString()
    {
        var hours = Hours.ToString().Length == 2 ? Hours.ToString() : $"0{Hours}";
        var minutes = Minutes.ToString().Length == 2 ? Minutes.ToString() : $"0{Minutes}";
        var seconds = Seconds.ToString().Length == 2 ? Seconds.ToString() : $"0{Seconds}";
        var ms = Milliseconds.ToString();

        return $"{hours}:{minutes}:{seconds}:{ms}";
    }

    public void Reset()
    {
        Hours = _zero;
        Minutes = _zero;
        Seconds = _zero;
        Milliseconds = _zero;
        MillisecondDisplayHelper.DisplayZero();
        IsZero = true;
    }
}
