using AnalogTimer.Contracts;
using AnalogTimer.Models;
using AnalogTimer.Models.Enums;

namespace TimerEngine.Implementations.DisplayServices;

public class WinFormDisplayService : IDisplayService
{
    private readonly Action _callback;

    public WinFormDisplayService(Action callback)
    {
        _callback = callback;
    }

    public void ChangeHandler(DisplayHandler handler)
    {
        //throw new NotImplementedException();
    }

    public void Display(TimerState state)
    {
        _callback?.Invoke();
        //throw new NotImplementedException();
    }

    public void SetMode(DisplayMode mode)
    {
        //throw new NotImplementedException();
    }
}
