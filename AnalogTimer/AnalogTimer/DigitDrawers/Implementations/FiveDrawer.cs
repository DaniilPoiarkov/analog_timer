﻿using AnalogTimer.Contracts;

namespace AnalogTimer.DigitDrawers.Implementations;

public class FiveDrawer : DigitDrawerBase
{
    public override void Draw(int positionLeft, ITimerTemplate template)
    {
        Clear(positionLeft);

        PrintWidthLine(0, positionLeft, template.Pattern);
        PrintWidthLine(3, positionLeft, template.Pattern);
        PrintWidthLine(6, positionLeft, template.Pattern);

        PrintHeightLine(true, positionLeft, template.Pattern);

        PrintHeightLine(false, positionLeft + 7, template.Pattern);

        SetCursor();
    }

    public override void DrawDown(int positionLeft, ITimerTemplate template)
    {
        ClearHeightLine(false, positionLeft);

        SetCursor();
    }

    public override void DrawUp(int positionLeft, ITimerTemplate template)
    {
        throw new NotImplementedException();
    }
}
