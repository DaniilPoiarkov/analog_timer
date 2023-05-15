using MyTimer = AnalogTimer.Implementations.AnalogTimer;
using System.Diagnostics;
using TimerEngine.Implementations.DisplayServices;
using AnalogTimer.Contracts;
using AnalogTimer.Models.Enums;
using AnalogTimer.Models;
using AnalogTimer.Implementations;
using AnalogTimer.Prompts.Implementations;

namespace WinApplication;

public partial class AnalogTimerForm : Form
{
    private readonly MyTimer _timer;

    private readonly IDisplayService _displayService;

    private readonly IPromptService _promptService;

    private int hours;

    private int minutes;

    private int seconds;

    public AnalogTimerForm()
    {
        InitializeComponent();

        _displayService = new WinFormDisplayService(
            () => outputLabel.Text = _timer?.GetSnapshot().ToString());

        _timer = new MyTimer(new(), _displayService);

        _promptService = new PromptServiceBuilder(_timer)
            .Add<StartPrompt>()
            .Add<PausePrompt>()
            .Add<ResetPrompt>()
            .Add<AddSecondsPrompt>()
            .Add<AddMinutesPrompt>()
            .Add<AddHoursPrompt>()
            .Add<ChangeSpeedPrompt>()
            .Add<ChangeTimerTypePrompt>()
            .Add<CloseTimerPrompt>()
            .Build();
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

        try
        {
            _timer.Start();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void PauseBtn_Click(object sender, EventArgs e)
    {
        try
        {
            await _timer.Stop();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void HoursInput_Click(object sender, EventArgs e)
    {
        hours = (int)HoursInput.Value;
    }

    private void MinutesInput_Click(object sender, EventArgs e)
    {
        minutes = (int)MinutesInput.Value;
    }

    private void SecondsInput_Click(object sender, EventArgs e)
    {
        seconds = (int)SecondsInput.Value;
    }

    private void OpenConsoleBtn_Click(object sender, EventArgs e)
    {
        if (!ConsoleInput.Enabled)
        {
            OpenConsoleBtn.Text = "Disable console mode";
            ConsoleInput.Enabled = true;
        }
        else
        {
            OpenConsoleBtn.Text = "Enable console mode";
            ConsoleInput.Enabled = false;
            ConsoleInput.Text = string.Empty;
        }
    }

    private void TimerTypeChanged(object sender, EventArgs e)
    {
        try
        {
            var type = Enum.Parse<TimerType>(TimerTypeComboBox.Text);
            _timer.SetTimerType(type);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void ConsoleInputEnterKeydown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode != Keys.Enter)
        {
            return;
        }

        try
        {
            await _promptService.Consume(ConsoleInput.Text);
            ConsoleInput.Text = string.Empty;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
