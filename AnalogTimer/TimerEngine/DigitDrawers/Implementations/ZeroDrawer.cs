﻿using AnalogTimer.Contracts;

namespace AnalogTimer.DigitDrawers.Implementations;

public class ZeroDrawer : DigitDrawerBase
{
    public override List<List<char>> Matrix => new()
    {
        new List<char>() { '█', '█', '█', '█', '█', '█', '█',},
        new List<char>() { '█', ' ', ' ', ' ', ' ', ' ', '█'},
        new List<char>() { '█', ' ', ' ', ' ', ' ', ' ', '█'},
        new List<char>() { '█', ' ', ' ', ' ', ' ', ' ', '█'},
        new List<char>() { '█', ' ', ' ', ' ', ' ', ' ', '█'},
        new List<char>() { '█', ' ', ' ', ' ', ' ', ' ', '█'},
        new List<char>() { '█', ' ', ' ', ' ', ' ', ' ', '█'},
        new List<char>() { '█', '█', '█', '█', '█', '█', '█',},
    };

    public override List<string> Pattern => new()
    {
        "████████",
        "█      █",
        "█      █",
        "█      █",
        "█      █",
        "█      █",
        "████████",
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
    }

    public override void DrawDown(int positionLeft, ITimerTemplate template)
    {
        PrintWidthLine(0, positionLeft, template.Pattern);
        PrintWidthLine(6, positionLeft, template.Pattern);

        PrintHeightLine(true, positionLeft, template.Pattern);
        PrintHeightLine(false, positionLeft, template.Pattern);
    }

    public override void DrawUp(int positionLeft, ITimerTemplate template)
    {
        ClearWidthLine(3, positionLeft);
        PrintHeightLine(false, positionLeft, template.Pattern);
    }
}
