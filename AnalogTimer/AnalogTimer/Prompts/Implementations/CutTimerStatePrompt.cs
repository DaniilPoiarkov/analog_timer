using AnalogTimer.Contracts;

namespace AnalogTimer.Prompts.Implementations;

public class CutTimerStatePrompt : PromptBase
{
    private static int PositionTop = 25;

    private static int PositionLeft = 0;

    public override string Name => "cut";

    public override string Instruction => "Write \'cut\' or \'-c\' when timer is running to print its current state";

    public override string Shortcut => "-c";

    public override Task Proceed(string input, IAnalogTimer timer)
    {
        var snapshot = timer.GetSnapshot();

        if (PositionTop >= 29)
        {
            PositionTop = 25;
            PositionLeft += 21;
        }

        if(PositionLeft >= 104)
        {
            PositionTop = 25;
            PositionLeft = 0;
        }

        Console.CursorTop = PositionTop;
        Console.CursorLeft = PositionLeft;

        Console.WriteLine($"|{DateTime.UtcNow.ToShortTimeString()}: {snapshot}|");
        PositionTop++;

        return Task.CompletedTask;
    }
}
