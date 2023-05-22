﻿using AnalogTimer.Contracts;

namespace AnalogTimer.DigitDrawers.Implementations;

public class ThreeDrawer : DigitDrawerBase
{
    public override List<List<char>> Matrix => new()
    {
        new() {'█', ' ', ' ', '█', ' ', ' ', '█',},
        new() {'█', ' ', ' ', '█', ' ', ' ', '█',},
        new() {'█', ' ', ' ', '█', ' ', ' ', '█',},
        new() {'█', ' ', ' ', '█', ' ', ' ', '█',},
        new() {'█', ' ', ' ', '█', ' ', ' ', '█',},
        new() {'█', ' ', ' ', '█', ' ', ' ', '█',},
        new() {'█', ' ', ' ', '█', ' ', ' ', '█',},
        new() {'█', '█', '█', '█', '█', '█', '█',},
    };

    public override List<string> Pattern => new()
    {
        "████████",
        "       █",
        "       █",
        "████████",
        "       █",
        "       █",
        "████████",
    };

    public override void Draw(int positionLeft, ITimerTemplate template)
    {
        Clear(positionLeft);

        PrintWidthLine(0, positionLeft, template.Pattern);
        PrintWidthLine(3, positionLeft, template.Pattern);
        PrintWidthLine(6, positionLeft, template.Pattern);

        PrintHeightLine(true, positionLeft + 7, template.Pattern);
        PrintHeightLine(false, positionLeft + 7, template.Pattern);
    }

    public override void DrawDown(int positionLeft, ITimerTemplate template)
    {
        ClearHeightLine(true, positionLeft);

        PrintWidthLine(0, positionLeft, template.Pattern);
        PrintWidthLine(6, positionLeft, template.Pattern);
    }

    public override void DrawUp(int positionLeft, ITimerTemplate template)
    {
        ClearHeightLine(false, positionLeft);

        PrintHeightLine(false, positionLeft + 7, template.Pattern);
    }
}
