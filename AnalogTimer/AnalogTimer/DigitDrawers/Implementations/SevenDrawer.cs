using AnalogTimer.Contracts;

namespace AnalogTimer.DigitDrawers.Implementations;

public class SevenDrawer : DigitDrawerBase
{
    public override bool[,] Matrix => throw new NotImplementedException();

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

        ClearWidthLines(positionLeft);

        SetCursor();
    }

    public override void DrawUp(int positionLeft, ITimerTemplate template)
    {
        ClearWidthLines(positionLeft);
        ClearHeightLine(true, positionLeft);
        ClearHeightLine(false, positionLeft);

        PrintHeightLine(true, positionLeft + 7, template.Pattern);

        SetCursor();
    }

    private static void ClearWidthLines(int positionLeft)
    {
        ClearWidthLine(3, positionLeft);
        Console.CursorTop = 3;
        Console.CursorLeft = positionLeft;
        Console.WriteLine(_empty);
        ClearWidthLine(6, positionLeft);
        Console.CursorTop = 6;
        Console.CursorLeft = positionLeft;
        Console.WriteLine(_empty);
    }
}
