using AnalogTimer.Models;
using TimerEngine.Models.Enums;

namespace TimerEngine.Models.TimerEventArgs;

public class TimerEventArgs
{
    public TimerState? State { get; set; }

    public TimerType? TimerType { get; set; }
}
