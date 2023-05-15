using MyTimer = AnalogTimer.Implementations.AnalogTimer;
using System.Diagnostics;
using TimerEngine.Implementations.DisplayServices;
using AnalogTimer.Contracts;
using NLog;
using AnalogTimer.Models.Enums;

namespace WinApplication;

public partial class AnalogTimerForm : Form
{
    private readonly MyTimer _timer;

    private readonly IDisplayService _displayService;

    private readonly Logger _logger = LogManager.GetCurrentClassLogger();

    public AnalogTimerForm()
    {
        InitializeComponent();
        _displayService = new WinFormDisplayService(() => outputLabel.Text = _timer?.GetSnapshot().ToString());
        _timer = new MyTimer(new(), _displayService);
    }

    private void StartBtn_Click(object sender, EventArgs e)
    {
        outputLabel.Text = $"{HoursInput.Value}:{MinutesInput.Value}:{SecondsInput.Value}";
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
            outputLabel.Text = string.Empty;
            _timer.ResetState();
        }
        catch (Exception ex)
        {
            _logger.Error(ex);
        }
    }

    private void HoursInput_Click(object sender, EventArgs e)
    {
        try
        {
            _timer.ResetState();
            _timer.AddHours((int)((dynamic)sender).Value);
        }
        catch (Exception ex)
        {
            _logger.Warn(ex);
        }
    }

    private void MinutesInput_Click(object sender, EventArgs e)
    {
        try
        {
            _timer.ResetState();
            _timer.AddMinutes(((dynamic)sender).Value);
        }
        catch (Exception ex)
        {
            _logger.Warn(ex);
        }
    }

    private void SecondsInput_Click(object sender, EventArgs e)
    {
        try
        {
            _timer.ResetState();
            _timer.AddSeconds(((dynamic)sender).Value);
        }
        catch (Exception ex)
        {
            _logger.Warn(ex);
        }
    }

    private void OpenConsoleBtn_Click(object sender, EventArgs e)
    {

    }

    private void TimerTypeChanged(object sender, EventArgs e)
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
