using AnalogTimer.Contracts;
using AnalogTimer.Helpers;

namespace AnalogTimer.DigitDrawers.Implementations;

public class FiveDrawer : DigitDrawerBase
{
    public override bool[,] Matrix => new bool[,]
    {
        {true, true, true, true, false, false, true,},
        {true, false, false, true, false, false, true,},
        {true, false, false, true, false, false, true,},
        {true, false, false, true, false, false, true,},
        {true, false, false, true, false, false, true,},
        {true, false, false, true, false, false, true,},
        {true, false, false, true, false, false, true,},
        {true, false, false, true, true, true, true,},
    };

    public override void Draw(int positionLeft, ITimerTemplate template)
    {
        Clear(positionLeft);

        PrintWidthLine(0, positionLeft, template.Pattern);
        PrintWidthLine(3, positionLeft, template.Pattern);
        PrintWidthLine(6, positionLeft, template.Pattern);

        PrintHeightLine(true, positionLeft, template.Pattern);

        PrintHeightLine(false, positionLeft + 7, template.Pattern);

        UIHelper.SetCursor();
    }

    public override void DrawDown(int positionLeft, ITimerTemplate template)
    {
        ClearHeightLine(false, positionLeft);

        UIHelper.SetCursor();
    }

    public override void DrawUp(int positionLeft, ITimerTemplate template)
    {
        ClearHeightLine(true, positionLeft + 7);
        PrintWidthLine(0, positionLeft, template.Pattern);
        PrintWidthLine(6, positionLeft, template.Pattern);

        UIHelper.SetCursor();
    }
}
