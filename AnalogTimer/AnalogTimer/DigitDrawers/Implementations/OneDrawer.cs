using AnalogTimer.Contracts;

namespace AnalogTimer.DigitDrawers.Implementations;

public class OneDrawer : DigitDrawerBase
{
    public override void Draw(int positionLeft, ITimerTemplate template)
    {
        Clear(positionLeft);

        PrintHeightLine(true, positionLeft + 7, template.Pattern);
        PrintHeightLine(false, positionLeft + 7, template.Pattern);

        SetCursor();
    }

    public override void DrawDown(int positionLeft, ITimerTemplate template)
    {
        ClearWidthLine(0, positionLeft);
        Console.CursorTop = 0;
        Console.CursorLeft = 0;
        Console.WriteLine(_empty);

        ClearWidthLine(3, positionLeft);
        Console.CursorTop = 3;
        Console.CursorLeft = 0;
        Console.WriteLine(_empty);

        ClearWidthLine(6, positionLeft);
        Console.CursorTop = 6;
        Console.CursorLeft = 0;
        Console.WriteLine(_empty);

        ClearHeightLine(false, positionLeft);
        PrintHeightLine(false, positionLeft + 7, template.Pattern);

        SetCursor();
    }

    public override void DrawUp(int positionLeft, ITimerTemplate template)
    {
        throw new NotImplementedException();
    }
}
