using AnalogTimer.Contracts;
using AnalogTimer.Models;
using AnalogTimer.Models.Enums;
using System.Drawing;

namespace TimerEngine.Implementations.DisplayServices;

public class WinFormDisplayService : IDisplayService
{
    private readonly Action _callback;

    private readonly Pen _pen;

    public WinFormDisplayService(Action callback)
    {
        _callback = callback;
        _pen = new(Color.FromArgb(255, 255, 255));
    }

    public void ChangeHandler(DisplayHandler handler)
    {
        
    }

    public void Display(TimerState state)
    {
        _callback?.Invoke();
    }

    public void SetMode(DisplayMode mode)
    {
        
    }
}
