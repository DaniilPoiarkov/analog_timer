using AnalogTimer.Models;

namespace AnalogTimer.Contracts;

public interface IDisplayService
{
    void Display(TimerState state);
}
