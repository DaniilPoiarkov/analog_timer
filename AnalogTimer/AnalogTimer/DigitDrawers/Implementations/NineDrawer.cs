using AnalogTimer.Contracts;
using AnalogTimer.Helpers;

namespace AnalogTimer.DigitDrawers.Implementations;

public class NineDrawer : DigitDrawerBase
{
    public override List<List<bool>> Matrix => new()
    {
        new() {true, true, true, true, false, false, true,},
        new() {true, false, false, true, false, false, true,},
        new() {true, false, false, true, false, false, true,},
        new() {true, false, false, true, false, false, true,},
        new() {true, false, false, true, false, false, true,},
        new() {true, false, false, true, false, false, true,},
        new() {true, false, false, true, false, false, true,},
        new() {true, true, true, true, true, true, true,},
    };

    public override void Draw(int positionLeft, ITimerTemplate template)
    {
        Clear(positionLeft);

        PrintWidthLine(0, positionLeft, template.Pattern);
        PrintWidthLine(3, positionLeft, template.Pattern);
        PrintWidthLine(6, positionLeft, template.Pattern);

        PrintHeightLine(true, positionLeft, template.Pattern);
        PrintHeightLine(true, positionLeft + 7, template.Pattern);

        PrintHeightLine(false, positionLeft + 7, template.Pattern);

        UIHelper.SetCursor();
    }

    public override void DrawDown(int positionLeft, ITimerTemplate template)
    {
        PrintWidthLine(3, positionLeft, template.Pattern);
        ClearHeightLine(false, positionLeft);

        UIHelper.SetCursor();
    }

    public override void DrawUp(int positionLeft, ITimerTemplate template)
    {
        ClearHeightLine(false, positionLeft);

        UIHelper.SetCursor();
    }
}
