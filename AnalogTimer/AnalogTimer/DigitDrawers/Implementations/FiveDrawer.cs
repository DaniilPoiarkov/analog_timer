using AnalogTimer.Contracts;
using AnalogTimer.Helpers;

namespace AnalogTimer.DigitDrawers.Implementations;

public class FiveDrawer : DigitDrawerBase
{
    public override List<List<char>> Matrix => new()
    {
        new() {'█', '█', '█', '█', ' ', ' ', '█',},
        new() {'█', ' ', ' ', '█', ' ', ' ', '█',},
        new() {'█', ' ', ' ', '█', ' ', ' ', '█',},
        new() {'█', ' ', ' ', '█', ' ', ' ', '█',},
        new() {'█', ' ', ' ', '█', ' ', ' ', '█',},
        new() {'█', ' ', ' ', '█', ' ', ' ', '█',},
        new() {'█', ' ', ' ', '█', ' ', ' ', '█',},
        new() {'█', ' ', ' ', '█', '█', '█', '█',},
    };

    public override List<string> Pattern => new()
    {
        "████████",
        "█       ",
        "█       ",
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
