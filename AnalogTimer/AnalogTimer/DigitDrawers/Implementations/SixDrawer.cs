using AnalogTimer.Contracts;

namespace AnalogTimer.DigitDrawers.Implementations;

public class SixDrawer : DigitDrawerBase
{
    public override bool[,] Matrix => throw new NotImplementedException();

    public override void Draw(int positionLeft, ITimerTemplate template)
    {
        Clear(positionLeft);

        PrintWidthLine(0, positionLeft, template.Pattern);
        PrintWidthLine(3, positionLeft, template.Pattern);
        PrintWidthLine(6, positionLeft, template.Pattern);

        PrintHeightLine(true, positionLeft, template.Pattern);

        PrintHeightLine(false, positionLeft, template.Pattern);
        PrintHeightLine(false, positionLeft + 7, template.Pattern);

        SetCursor();
    }

    public override void DrawDown(int positionLeft, ITimerTemplate template)
    {
        PrintWidthLine(3, positionLeft, template.Pattern);
        PrintWidthLine(6, positionLeft, template.Pattern);

        ClearHeightLine(true, positionLeft + 7);

        PrintHeightLine(true, positionLeft, template.Pattern);
        PrintHeightLine(false, positionLeft, template.Pattern);

        SetCursor();
    }

    public override void DrawUp(int positionLeft, ITimerTemplate template)
    {
        PrintHeightLine(false, positionLeft, template.Pattern);

        SetCursor();
    }
}
