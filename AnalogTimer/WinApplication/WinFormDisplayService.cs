using AnalogTimer.Contracts;
using AnalogTimer.Models;
using AnalogTimer.Models.Enums;

namespace TimerEngine.Implementations.DisplayServices;

public class WinFormDisplayService : IDisplayService
{
    private readonly Graphics _graphics;

    private TimerState? _snapshoot;

    public WinFormDisplayService(Graphics graphics)
    {
        _graphics = graphics;
    }

    public void ChangeHandler(DisplayHandler handler)
    {
        
    }

    public void Display(TimerState state)
    {
        if(_snapshoot is not null)
            _graphics.DrawString(_snapshoot.ToString(), new Font(FontFamily.GenericSansSerif, 50), new SolidBrush(Color.FromArgb(32, 42, 62)), 15, 15);

        _graphics.DrawString(state.ToString(), new Font(FontFamily.GenericSansSerif, 50), new SolidBrush(Color.White) , 15, 15);
        _snapshoot = state;
    }

    public void SetMode(DisplayMode mode)
    {
        
    }
}
