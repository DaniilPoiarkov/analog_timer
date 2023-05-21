using AnalogTimer.Contracts;
using AnalogTimer.Models;
using TimerEngine.Models.TimerEventArgs;

namespace TimerEngine.Implementations.DisplayServices;

public class WinFormDisplayService : IDisplayService
{
    private readonly Label _output;

    public WinFormDisplayService(Label outputLabel)
    {
        _output = outputLabel;
    }

    public void Display(TimerState state)
    {
        _output.Text = state.ToString();
    }

    public void HandleTimerUpdated(TimerEventArgs args)
    {
        _output.Text = args.State?.ToString();
    }
}
