using AnalogTimer.Models;
using TimerEngine.Models.TimerEventArgs;

namespace AnalogTimer.Contracts;

// TODO: Rework + remove
public interface IDisplayService
{
    void DisplayTick(TimerState state);

    void DisplayUpdated(TimerEventArgs args);

    void DisplayCut(TimerEventArgs args);
}
