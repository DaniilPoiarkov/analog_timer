using AnalogTimer.Contracts;

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

        SetCursor();
    }

    public override void DrawDown(int positionLeft, ITimerTemplate template)
    {
        ClearWidthLine(0, positionLeft);
        ClearWidthLine(6, positionLeft);
        Console.CursorTop = 6;
        Console.CursorLeft = 0;
        Console.WriteLine(_empty);

        PrintHeightLine(true, positionLeft + 7, template.Pattern);

        SetCursor();
    }

    public override void DrawUp(int positionLeft, ITimerTemplate template)
    {
        throw new NotImplementedException();
    }
}
