using AnalogTimer.Contracts;
using AnalogTimer.Helpers;

namespace AnalogTimer.DigitDrawers.Implementations;

public class ZeroDrawer : DigitDrawerBase
{
    public override List<List<bool>> Matrix => new()
    {
        new List<bool>() { true, true, true, true, true, true, true,},
        new List<bool>() { true, false, false, false, false, false, true},
        new List<bool>() { true, false, false, false, false, false, true},
        new List<bool>() { true, false, false, false, false, false, true},
        new List<bool>() { true, false, false, false, false, false, true},
        new List<bool>() { true, false, false, false, false, false, true},
        new List<bool>() { true, false, false, false, false, false, true},
        new List<bool>() { true, true, true, true, true, true, true,},
    };

    public override void Draw(int positionLeft, ITimerTemplate template)
    {
        Clear(positionLeft);

        PrintWidthLine(0, positionLeft, template.Pattern);
        PrintWidthLine(6, positionLeft, template.Pattern);

        PrintHeightLine(true, positionLeft, template.Pattern);
        PrintHeightLine(true, positionLeft + 7, template.Pattern);

        PrintHeightLine(false, positionLeft, template.Pattern);
        PrintHeightLine(false, positionLeft + 7, template.Pattern);

        UIHelper.SetCursor();
    }

    public override void DrawDown(int positionLeft, ITimerTemplate template)
    {
        PrintWidthLine(0, positionLeft, template.Pattern);
        PrintWidthLine(6, positionLeft, template.Pattern);

        PrintHeightLine(true, positionLeft, template.Pattern);
        PrintHeightLine(false, positionLeft, template.Pattern);

        UIHelper.SetCursor();
    }

    public override void DrawUp(int positionLeft, ITimerTemplate template)
    {
        ClearWidthLine(3, positionLeft);
        PrintHeightLine(false, positionLeft, template.Pattern);

        UIHelper.SetCursor();
    }
}
