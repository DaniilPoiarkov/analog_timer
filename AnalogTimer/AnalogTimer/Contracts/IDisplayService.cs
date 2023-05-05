using AnalogTimer.Models;
using AnalogTimer.Models.Enums;
using System.Threading;

namespace AnalogTimer.Contracts;

public interface IDisplayService
{
    void Display(TimerState state);

    void SetMode(DisplayMode mode);

    void ChangeHandler(DisplayHandler handler);

    Task StartBackgroundDisplay(CancellationToken token);
}
