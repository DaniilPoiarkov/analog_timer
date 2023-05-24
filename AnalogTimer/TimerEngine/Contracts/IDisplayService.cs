using AnalogTimer.Models;
using TimerEngine.Models.TimerEventArgs;

namespace AnalogTimer.Contracts;

public interface IDisplayService
{
    void DisplayTick(TimerState state);

    void DisplayUpdated(TimerEventArgs args);

    void DisplayCut(TimerEventArgs args);
}
