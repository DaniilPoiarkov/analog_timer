using AnalogTimer.Contracts;

namespace AnalogTimer.DigitDrawers.Implementations;

public class SevenDrawer : DigitDrawerBase
{
    public override void Draw(int positionLeft, ITimerTemplate template)
    {
        Clear(positionLeft);

        PrintWidthLine(0, positionLeft, template.Pattern);

        PrintHeightLine(true, positionLeft + 7, template.Pattern);
        PrintHeightLine(false, positionLeft + 7, template.Pattern);

        SetCursor();
    }

    public override void DrawDown(int positionLeft, ITimerTemplate template)
    {
        ClearHeightLine(true, positionLeft);
        ClearHeightLine(false, positionLeft);

        ClearWidthLine(3, positionLeft);
        Console.CursorTop = 3;
        Console.CursorLeft = 0;
        Console.WriteLine(_empty);
        ClearWidthLine(6, positionLeft);
        Console.CursorTop = 6;
        Console.CursorLeft = 0;
        Console.WriteLine(_empty);

        SetCursor();
    }

    public override void DrawUp(int positionLeft, ITimerTemplate template)
    {
        throw new NotImplementedException();
    }
}
