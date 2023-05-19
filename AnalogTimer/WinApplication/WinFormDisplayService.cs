using AnalogTimer.Contracts;
using AnalogTimer.DigitDrawers;
using AnalogTimer.Models;
using AnalogTimer.Models.Enums;

namespace TimerEngine.Implementations.DisplayServices;

public class WinFormDisplayService : IDisplayService
{
    private readonly Graphics _graphics;

    private TimerState? _snapshoot;

    private int x = 5;

    private int _spaceBetweenDigits = 15;

    private const char _empty = ' ';

    public WinFormDisplayService(Graphics graphics)
    {
        _graphics = graphics;
    }

    public void ChangeHandler(DisplayHandler handler)
    {
        
    }

    public void Display(TimerState state)
    {
        var backColor = Color.FromArgb(32, 42, 62);
        var font = new Font(FontFamily.GenericSansSerif, 2);

        var pen = new Pen(new SolidBrush(Color.White));

        var x = state.Seconds.ToString().Length == 2 ? state.Seconds.ToString() : $"0{state.Seconds}";

        var sec = x
            .Select(s => int.Parse(s.ToString()))
            .Select(DigitDrawerProvider.GetDrawer)
            .Select(p => p.Pattern)
            .Aggregate((first, second) => first.Zip(second)
                .Select((pair) => $"{pair.First}{new string(_empty, _spaceBetweenDigits)}{pair.Second}")
                .ToList());

        int startPositionTop = 25;
        int positionLeft = 25;

        foreach (var line in sec)
        {
            //_graphics.DrawLine(new Pen(backColor, 2), new Point(positionLeft, startPositionTop), new Point(positionLeft, startPositionTop + line.Length));// new SolidBrush(backColor)
            _graphics.DrawString(line, font, new SolidBrush(backColor), new Point(positionLeft, startPositionTop));
            _graphics.DrawString(line, font, new SolidBrush(Color.White), new Point(positionLeft, startPositionTop));

            //_graphics.DrawLine(pen, new Point(startPositionTop, positionLeft), new Point(startPositionTop, positionLeft + line.Length));
            startPositionTop += 5;
        }

        //if (_snapshoot is not null)
        //_graphics.DrawLine(pen, x, x * 2, x + 5, (x + 5) * 2);

        //x++;

        //_graphics.DrawString(state.ToString(), new Font(FontFamily.GenericSansSerif, 50), new SolidBrush() , 15, 15);
        //_snapshoot = state;
    }

    public void SetMode(DisplayMode mode)
    {
        
    }
}
