﻿using AnalogTimer.Contracts;
using AnalogTimer.Helpers;

namespace AnalogTimer.DigitDrawers.Implementations;

public class SevenDrawer : DigitDrawerBase
{
    public override List<List<char>> Matrix => new()
    {
        new() {'█', ' ', ' ', ' ', ' ', ' ', ' ',},
        new() {'█', ' ', ' ', ' ', ' ', ' ', ' ',},
        new() {'█', ' ', ' ', ' ', ' ', ' ', ' ',},
        new() {'█', ' ', ' ', ' ', ' ', ' ', ' ',},
        new() {'█', ' ', ' ', ' ', ' ', ' ', ' ',},
        new() {'█', ' ', ' ', ' ', ' ', ' ', ' ',},
        new() {'█', ' ', ' ', ' ', ' ', ' ', ' ',},
        new() {'█', '█', '█', '█', '█', '█', '█',},
    };

    public override void Draw(int positionLeft, ITimerTemplate template)
    {
        Clear(positionLeft);

        PrintWidthLine(0, positionLeft, template.Pattern);

        PrintHeightLine(true, positionLeft + 7, template.Pattern);
        PrintHeightLine(false, positionLeft + 7, template.Pattern);

        UIHelper.SetCursor();
    }

    public override void DrawDown(int positionLeft, ITimerTemplate template)
    {
        ClearHeightLine(true, positionLeft);
        ClearHeightLine(false, positionLeft);

        ClearWidthLines(positionLeft);

        UIHelper.SetCursor();
    }

    public override void DrawUp(int positionLeft, ITimerTemplate template)
    {
        ClearWidthLines(positionLeft);
        ClearHeightLine(true, positionLeft);
        ClearHeightLine(false, positionLeft);

        PrintHeightLine(true, positionLeft + 7, template.Pattern);

        UIHelper.SetCursor();
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
