using AnalogTimer.Contracts;
using AnalogTimer.Helpers;

namespace AnalogTimer.DigitDrawers.Implementations;

public class FourDrawer : DigitDrawerBase
{
    public override List<List<char>> Matrix => new()
    {
        new() {'█', '█', '█', '█', ' ', ' ', ' ',},
        new() {' ', ' ', ' ', '█', ' ', ' ', ' ',},
        new() {' ', ' ', ' ', '█', ' ', ' ', ' ',},
        new() {' ', ' ', ' ', '█', ' ', ' ', ' ',},
        new() {' ', ' ', ' ', '█', ' ', ' ', ' ',},
        new() {' ', ' ', ' ', '█', ' ', ' ', ' ',},
        new() {' ', ' ', ' ', '█', ' ', ' ', ' ',},
        new() {'█', '█', '█', '█', '█', '█', '█',},
    };

    public override void Draw(int positionLeft, ITimerTemplate template)
    {
        Clear(positionLeft);

        PrintWidthLine(3, positionLeft, template.Pattern);

        PrintHeightLine(true, positionLeft, template.Pattern);
        PrintHeightLine(true, positionLeft + 7, template.Pattern);

        PrintHeightLine(false, positionLeft + 7, template.Pattern);

        UIHelper.SetCursor();
    }

    public override void DrawDown(int positionLeft, ITimerTemplate template)
    {
        ClearWidthLines(positionLeft);

        PrintHeightLine(true, positionLeft + 7, template.Pattern);

        UIHelper.SetCursor();
    }

    public override void DrawUp(int positionLeft, ITimerTemplate template)
    {
        ClearWidthLines(positionLeft);
        PrintHeightLine(true, positionLeft, template.Pattern);

        UIHelper.SetCursor();
    }

    private static void ClearWidthLines(int positionLeft)
    {
        ClearWidthLine(0, positionLeft);
        ClearWidthLine(6, positionLeft);

        Console.CursorTop = 6;
        Console.CursorLeft = positionLeft;
        Console.WriteLine(_empty);
    }
}
