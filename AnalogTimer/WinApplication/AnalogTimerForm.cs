using MyTimer = AnalogTimer.Implementations.AnalogTimer;
using System.Diagnostics;
using TimerEngine.Implementations.DisplayServices;
using AnalogTimer.Contracts;
using NLog;
using AnalogTimer.Models.Enums;
using AnalogTimer.Models;

namespace WinApplication;

public partial class AnalogTimerForm : Form
{
    private readonly MyTimer _timer;

    private readonly IDisplayService _displayService;

    private readonly Logger _logger = LogManager.GetCurrentClassLogger();

    private int hours;

    private int minutes;

    private int seconds;

    public AnalogTimerForm()
    {
        InitializeComponent();
        _displayService = new WinFormDisplayService(() => outputLabel.Text = _timer?.GetSnapshot().ToString());
        _timer = new MyTimer(new(), _displayService);
    }

    private void StartBtn_Click(object sender, EventArgs e)
    {
        var state = new TimerState(hours, minutes, seconds, 0);

        hours = minutes = seconds = 0;

        if (!state.IsZero)
        {
            _timer.ResetState();
            _timer.AddHours(state.Hours);
            _timer.AddMinutes(state.Minutes);
            _timer.AddSeconds(state.Seconds);

            HoursInput.Value = hours;
            MinutesInput.Value = minutes;
            SecondsInput.Value = seconds;
        }

        _timer.Start();
    }

    private async void PauseBtn_Click(object sender, EventArgs e)
    {
        try
        {
            await _timer.Stop();
        }
        catch (Exception ex)
        {
            _logger.Error(ex);
        }
    }

    private void ResetBtn_Click(object sender, EventArgs e)
    {
        try
        {
            _timer.ResetState();
        }
        catch (Exception ex)
        {
            _logger.Error(ex);
        }
    }

    private void HoursInput_Click(object sender, EventArgs e)
    {
        hours = (int)((dynamic)sender).Value;
    }

    private void MinutesInput_Click(object sender, EventArgs e)
    {
        minutes = (int)((dynamic)sender).Value;
    }

    private void SecondsInput_Click(object sender, EventArgs e)
    {
        seconds = (int)((dynamic)sender).Value;
    }

    private void OpenConsoleBtn_Click(object sender, EventArgs e)
    {

    }

    private void TimerTypeChanged(object sender, EventArgs e) //+
    {
        var type = Enum.Parse<TimerType>(((dynamic)sender).Text);
        try
        {
            _timer.SetTimerType(type);
        }
        catch(Exception ex)
        {
            _logger.Warn(ex);
        }
    }
}
