using AnalogTimer.Contracts;
using AnalogTimer.Helpers;

namespace AnalogTimer.DigitDrawers.Implementations;

public class TwoDrawer : DigitDrawerBase
{
    public override bool[,] Matrix => new bool[,]
    {
        {true, false, false, true, true, true, true,},
        {true, false, false, true, false, false, true,},
        {true, false, false, true, false, false, true,},
        {true, false, false, true, false, false, true,},
        {true, false, false, true, false, false, true,},
        {true, false, false, true, false, false, true,},
        {true, false, false, true, false, false, true,},
        {true, true, true, true, false, false, true,},
    };

    public override void Draw(int positionLeft, ITimerTemplate template)
    {
        Clear(positionLeft);

        PrintWidthLine(0, positionLeft, template.Pattern);
        PrintWidthLine(3, positionLeft, template.Pattern);
        PrintWidthLine(6, positionLeft, template.Pattern);

        PrintHeightLine(true, positionLeft + 7, template.Pattern);
        PrintHeightLine(false, positionLeft, template.Pattern);

        UIHelper.SetCursor();
    }

    public override void DrawDown(int positionLeft, ITimerTemplate template)
    {
        ClearHeightLine(false, positionLeft + 7);
        PrintHeightLine(false, positionLeft, template.Pattern);

        UIHelper.SetCursor();
    }

    public override void DrawUp(int positionLeft, ITimerTemplate template)
    {
        PrintWidthLine(0, positionLeft, template.Pattern);
        PrintWidthLine(3, positionLeft, template.Pattern);
        PrintWidthLine(6, positionLeft, template.Pattern);

        PrintHeightLine(false, positionLeft, template.Pattern);

        ClearHeightLine(false, positionLeft + 7);

        UIHelper.SetCursor();
    }
}
