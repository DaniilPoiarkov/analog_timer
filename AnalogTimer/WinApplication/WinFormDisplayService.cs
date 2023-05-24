using AnalogTimer.Contracts;
using AnalogTimer.Models;
using TimerEngine.Models.TimerEventArgs;

namespace TimerEngine.Implementations.DisplayServices;

public class WinFormDisplayService : IDisplayService
{
    private readonly Label _output;

    private readonly TextBox _cutOutput;

    private int _cutClicks;

    public WinFormDisplayService(Label outputLabel, TextBox cutOutput)
    {
        _output = outputLabel;
        _cutOutput = cutOutput;
    }

    public void DisplayTick(TimerState state)
    {
        _output.Text = state.ToString();
    }

    public void DisplayCut(TimerEventArgs args)
    {
        if (_cutClicks == 3)
        {
            _cutClicks = 0;
            _cutOutput.Text = string.Empty;
        }

        _cutClicks++;
        _cutOutput.Text += $"|{DateTime.UtcNow.ToShortTimeString()} => {args.State}{Environment.NewLine}";
    }

    public void DisplayUpdated(TimerEventArgs args)
    {
        _output.Text = args.State?.ToString();
    }
}
