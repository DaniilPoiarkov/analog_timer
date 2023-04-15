using AnalogTimer.Contracts;

namespace AnalogTimer.DigitDrawers.Implementations;

public class OneDrawer : DigitDrawerBase
{
    public override void Draw(int positionLeft, ITimerTemplate template)
    {
        Clear(positionLeft);

        PrintHeightLine(true, positionLeft + 7, template.Pattern);
        PrintHeightLine(false, positionLeft + 7, template.Pattern);

        Console.CursorTop = 9;
    }
}
