namespace AnalogTimer.Models;

public class TimerState
{
    public int Hours { get; private set; }
    public int Minutes { get; private set; }
    public int Seconds { get; private set; }
    //public int Milliseconds { get; private set; }
    public bool IsZero { get; private set; }


    private const int _secondsInMinute = 59;

    private const int _maxValueInMinuteOrHour = 60;

    private const int _zero = 0;


    public TimerState(int hours, int minutes, int seconds)
    {
        Hours = hours;
        Minutes = minutes;
        Seconds = seconds;

        IsZero = Hours == _zero
            && Minutes == _zero
            && Seconds == _zero;
    }

    public TimerState(int hours, int minutes)
        : this(hours, minutes, _zero) { }

    public TimerState()
        : this(_zero, _zero) { }

    public void SubtractSeconds(int seconds)
    {
        Seconds -= seconds;

        if (Seconds < _zero)
        {
            var minutes = _zero;

            while (Seconds < _zero && minutes <= Minutes + Hours * _maxValueInMinuteOrHour)
            {
                minutes++;
                Seconds += 60;
            }

            SubtractMinutes(minutes);
        }

        if (Seconds < _zero)
        {
            Seconds = _zero;
        }

        IsZero = Seconds == _zero
            && Minutes == _zero
            && Hours == _zero;
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

        IsZero = Seconds == _zero
            && Minutes == _zero
            && Hours == _zero;
    }

    public void SubtractHours(int hours)
    {
        Hours -= hours;

        if (Hours < _zero)
        {
            Hours = _zero;
        }

        IsZero = Seconds == _zero
            && Minutes == _zero
            && Hours == _zero;
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

        //var ms = Milliseconds.ToString().Length == 2 ? Seconds.ToString() : $"0{Milliseconds}";

        return $"{hours}:{minutes}:{seconds}";
    }

    public void Reset()
    {
        Hours = _zero;
        Minutes = _zero;
        Seconds = _zero;
        IsZero = true;
    }
}
