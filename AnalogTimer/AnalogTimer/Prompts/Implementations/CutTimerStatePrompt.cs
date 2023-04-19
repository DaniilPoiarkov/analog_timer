using AnalogTimer.Contracts;

namespace AnalogTimer.Prompts.Implementations;

public class CutTimerStatePrompt : PromptBase
{
    private const int _startPositionTop = 25;

    private const int _startPositionLeft = 0;

    private const int _maxPositionLeft = 104;

    private const int _maxPositionTop = 29;

    private const int _space = 23;


    private static int PositionTop = _startPositionTop;

    private static int PositionLeft = _startPositionLeft;

    public override string Name => "cut";

    public override string Instruction => "Write \'cut\' or \'-c\' when timer is running to print its current state";

    public override string Shortcut => "-c";

    public override Task Proceed(string input, IAnalogTimer timer)
    {
        var snapshot = timer.GetSnapshot();

        if (PositionTop >= _maxPositionTop)
        {
            PositionTop = _startPositionTop;
            PositionLeft += _space;
        }

        if(PositionLeft >= _maxPositionLeft)
        {
            PositionTop = _startPositionTop;
            PositionLeft = _startPositionLeft;
        }

        Console.CursorTop = PositionTop;
        Console.CursorLeft = PositionLeft;

        Console.WriteLine($"|{DateTime.UtcNow.ToShortTimeString()} => {snapshot}|");
        PositionTop++;

        return Task.CompletedTask;
    }
}
