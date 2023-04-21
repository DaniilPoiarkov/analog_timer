using AnalogTimer.Contracts;

namespace AnalogTimer.DigitDrawers.Implementations;

public class OneDrawer : DigitDrawerBase
{
    public override bool[,] Matrix => throw new NotImplementedException();

    public override void Draw(int positionLeft, ITimerTemplate template)
    {
        Clear(positionLeft);

        PrintHeightLine(true, positionLeft + 7, template.Pattern);
        PrintHeightLine(false, positionLeft + 7, template.Pattern);

        SetCursor();
    }

    public override void DrawDown(int positionLeft, ITimerTemplate template)
    {
        ClearWidthLines(positionLeft);

        ClearHeightLine(false, positionLeft);
        PrintHeightLine(false, positionLeft + 7, template.Pattern);

        SetCursor();
    }

    public override void DrawUp(int positionLeft, ITimerTemplate template)
    {
        ClearWidthLines(positionLeft);

        ClearHeightLine(true, positionLeft);
        ClearHeightLine(false, positionLeft);

        SetCursor();
    }

    private static void ClearWidthLines(int positionLeft)
    {
        ClearWidthLine(0, positionLeft);
        Console.CursorTop = 0;
        Console.CursorLeft = positionLeft;
        Console.WriteLine(_empty);

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
