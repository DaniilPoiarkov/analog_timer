using AnalogTimer.Contracts;
using AnalogTimer.Helpers;

namespace AnalogTimer.DigitDrawers.Implementations;

public class OneDrawer : DigitDrawerBase
{
    public override List<List<char>> Matrix => new()
    {
        new() {' ', ' ', ' ', ' ', ' ', ' ', ' ',},
        new() {' ', ' ', ' ', ' ', ' ', ' ', ' ',},
        new() {' ', ' ', ' ', ' ', ' ', ' ', ' ',},
        new() {' ', ' ', ' ', ' ', ' ', ' ', ' ',},
        new() {' ', ' ', ' ', ' ', ' ', ' ', ' ',},
        new() {' ', ' ', ' ', ' ', ' ', ' ', ' ',},
        new() {' ', ' ', ' ', ' ', ' ', ' ', ' ',},
        new() {'█', '█', '█', '█', '█', '█', '█',},
    };

    public override List<string> Pattern => new()
    {
        "       █",
        "       █",
        "       █",
        "       █",
        "       █",
        "       █",
        "       █",
    };

    public override void Draw(int positionLeft, ITimerTemplate template)
    {
        Clear(positionLeft);

        PrintHeightLine(true, positionLeft + 7, template.Pattern);
        PrintHeightLine(false, positionLeft + 7, template.Pattern);

        UIHelper.SetCursor();
    }

    public override void DrawDown(int positionLeft, ITimerTemplate template)
    {
        ClearWidthLines(positionLeft);

        ClearHeightLine(false, positionLeft);
        PrintHeightLine(false, positionLeft + 7, template.Pattern);

        UIHelper.SetCursor();
    }

    public override void DrawUp(int positionLeft, ITimerTemplate template)
    {
        ClearWidthLines(positionLeft);

        ClearHeightLine(true, positionLeft);
        ClearHeightLine(false, positionLeft);

        UIHelper.SetCursor();
    }

    private static void ClearWidthLines(int positionLeft)
    {
        ClearWidthLine(0, positionLeft);
        Console.CursorTop = 0;
        Console.CursorLeft = positionLeft;
        Console.WriteLine(_empty);

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
