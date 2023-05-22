using AnalogTimer.Contracts;
using AnalogTimer.DigitDrawers;
using AnalogTimer.DisplayHandlers;
using AnalogTimer.Models;
using AnalogTimer.Models.Enums;

namespace TimerEngine.DisplayHandlers.ConsoleHandlers;

[Obsolete("Use MatrixDisplayHandler instead")]
public class DrawerDisplayHandler : DisplayHandlerBase
{
    private readonly DisplayMode _mode;

    private readonly ITimerTemplate _timerTemplate;

    private readonly TimerState? _snapshot;

    public DrawerDisplayHandler(
        ITimerTemplate timerTemplate,
        TimerState? snapshot,
        DisplayMode mode)
    {
        _timerTemplate = timerTemplate;
        _snapshot = snapshot;
        _mode = mode;
    }

    public override void Update(int digit, TimerValue value)
    {
        var values = TransformToEnumerable(digit, value);

        var positionLeft = GetPosition(value);

        var needFullRewrite = value switch
        {
            TimerValue.Hour => _snapshot?.Hours - digit > 1 || _snapshot?.Hours - digit < -1,
            TimerValue.Minute => _snapshot?.Minutes - digit > 1 || _snapshot?.Minutes - digit < -1,
            TimerValue.Second => _snapshot?.Seconds - digit > 1 || _snapshot?.Seconds - digit < -1,
            TimerValue.Millisecond => false,
            _ => throw new NotImplementedException(),
        };

        foreach (var num in values)
        {
            var drawer = DigitDrawerProvider.GetDrawer(num);

            if (needFullRewrite || _mode == DisplayMode.Full)
            {
                drawer.Draw(positionLeft, _timerTemplate);
            }
            else if (_mode == DisplayMode.Down)
            {
                drawer.DrawDown(positionLeft, _timerTemplate);
            }
            else
            {
                drawer.DrawUp(positionLeft, _timerTemplate);
            }

            positionLeft += _space;
        }
    }
}
