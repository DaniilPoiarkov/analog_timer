using AnalogTimer.Models;
using TimerEngine.Models.TimerEventArgs;

namespace WinApplication.Implementations;

internal class TimerDisplayService
{
    private readonly Label _output;

    public TimerDisplayService(Label output)
    {
        _output = output;
    }

    public void DisplayTick(TimerState state)
    {
        _output.Text = state.ToString();
    }

    public void DisplayUpdated(TimerEventArgs args)
    {
        _output.Text = args.State?.ToString();
    }
}
