using AnalogTimer.Contracts;
using AnalogTimer.Helpers;

namespace AnalogTimer.DigitDrawers.Implementations;

public class FourDrawer : DigitDrawerBase
{
    public override void Draw(int positionLeft, ITimerTemplate template)
    {
        Clear(positionLeft);

        PrintWidthLine(3, positionLeft, template.Pattern);

        PrintHeightLine(true, positionLeft, template.Pattern);
        PrintHeightLine(true, positionLeft + 7, template.Pattern);

        PrintHeightLine(false, positionLeft + 7, template.Pattern);

        Console.CursorLeft = UIHelper.CursorPosition;
        Console.CursorTop = 9;
    }
}
