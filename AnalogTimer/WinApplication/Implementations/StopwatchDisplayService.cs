using AnalogTimer.Contracts;
using AnalogTimer.Models;
using TimerEngine.Models.TimerEventArgs;

namespace WinApplication.Implementations;

public class StopwatchDisplayService : IDisplayService
{
    private readonly Label _output;

    private readonly TextBox _cutOutput;

    public StopwatchDisplayService(Label outputLabel, TextBox cutOutput)
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
        _cutOutput.Text += $"|{DateTime.UtcNow.ToShortTimeString()} => {args.State}{Environment.NewLine}";
    }

    public void DisplayUpdated(TimerEventArgs args)
    {
        _output.Text = args.State?.ToString();
    }
}
