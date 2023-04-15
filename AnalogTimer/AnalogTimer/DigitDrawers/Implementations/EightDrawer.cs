using AnalogTimer.Contracts;

namespace AnalogTimer.DigitDrawers.Implementations;

public class EightDrawer : DigitDrawerBase
{
    public override void Draw(int positionLeft, ITimerTemplate template)
    {
        Clear(positionLeft);

        PrintWidthLine(0, positionLeft, template.Pattern);
        PrintWidthLine(3, positionLeft, template.Pattern);
        PrintWidthLine(6, positionLeft, template.Pattern);

        PrintHeightLine(true, positionLeft, template.Pattern);
        PrintHeightLine(true, positionLeft + 7, template.Pattern);

        PrintHeightLine(false, positionLeft, template.Pattern);
        PrintHeightLine(false, positionLeft + 7, template.Pattern);

        Console.CursorLeft = 0;
        Console.CursorTop = 9;
    }
}
