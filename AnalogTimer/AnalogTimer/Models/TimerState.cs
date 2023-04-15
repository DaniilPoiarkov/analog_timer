namespace AnalogTimer.Models;

public class TimerState
{
    public int Hours { get; private set; }
    public int Minutes { get; private set; }
    public int Seconds { get; private set; }
    public bool IsZero { get; private set; }


    private const int _millisecondsInSecond = 1000;

    private const int _secondsInMinute = 60;

    private const int _minutesInHourMinusOne = 59;

    private const int _zero = 0;


    public TimerState(int hours, int minutes, int seconds)
    {
        Hours = hours;
        Minutes = minutes;
        Seconds = seconds;
    }

    public TimerState(int hours, int minutes)
        : this(hours, minutes, _zero) { }

    public TimerState()
        : this(0, 0) { }

    public void AddSeconds(int seconds) => Seconds += seconds;

    public void AddMinutes(int minutes) => Minutes += minutes;

    public void AddHours(int hours) => Hours += hours;

    public async Task Wait(int ticksPerSecond)
    {
        if (IsZero)
            throw new ArgumentOutOfRangeException(nameof(ticksPerSecond));

        await Task.Delay(_millisecondsInSecond / ticksPerSecond);

        //TODO
        Seconds -= (int)TimeSpan.FromMilliseconds(_millisecondsInSecond).TotalSeconds / ticksPerSecond;

        if (Seconds > _zero)
            return;

        if (Minutes > _zero)
        {
            Minutes--;
            Seconds = _secondsInMinute;
            return;
        }

        if (Hours > _zero)
        {
            Hours--;
            Minutes = _minutesInHourMinusOne;
            Seconds = _secondsInMinute;
            return;
        }

        if (Hours == _zero
            && Minutes == _zero
            && Seconds == _zero)
        {
            IsZero = true;
        }
    }

    public override string ToString()
    {
        var hours = Hours.ToString().Length == 2 ? Hours.ToString() : $"0{Hours}";
        var minutes = Minutes.ToString().Length == 2 ? Minutes.ToString() : $"0{Minutes}";
        var seconds = Seconds.ToString().Length == 2 ? Seconds.ToString() : $"0{Seconds}";
        return $"{hours}:{minutes}:{seconds}";
    }
}
