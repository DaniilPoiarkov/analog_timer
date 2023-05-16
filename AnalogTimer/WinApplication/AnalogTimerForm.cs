using MyTimer = AnalogTimer.Implementations.AnalogTimer;
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
            .Build();
    }

    private void StartBtn_Click(object sender, EventArgs e)
    {
        var state = new TimerState(hours, minutes, seconds, 0);

        if (!state.IsZero)
        {
            _timer.ResetState();
            _timer.AddHours(state.Hours);
            _timer.AddMinutes(state.Minutes);
            _timer.AddSeconds(state.Seconds);

            HoursInput.Value = 0;
            MinutesInput.Value = 0;
            SecondsInput.Value = 0;
        }

        UpdateTimerState(timer => timer.Start());
    }

    private async void PauseBtn_Click(object sender, EventArgs e)
    {
        await UpdateTimerState(async timer => await timer.Stop());
    }

    private void ResetBtn_Click(object sender, EventArgs e)
    {
        UpdateTimerState(timer => timer.ResetState());
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
        UpdateTimerState(timer =>
        {
            var type = Enum.Parse<TimerType>(TimerTypeComboBox.Text);
            timer.SetTimerType(type);
        });
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
            DisplayError(ex.Message);
        }
    }

    private void SpeedChangedEvent(object sender, EventArgs e)
    {
        var speedCoef = (int)ChangeSpeedInput.Value;

        UpdateTimerState(timer => timer.ChangeTicksPerSecond(speedCoef));
    }

    private async Task UpdateTimerState(Func<MyTimer, Task> action)
    {
        try
        {
            await action.Invoke(_timer);
        }
        catch (Exception ex)
        {
            DisplayError(ex.Message);
        }
    }

    private void UpdateTimerState(Action<MyTimer> action)
    {
        try
        {
            action.Invoke(_timer);
        }
        catch (Exception ex)
        {
            DisplayError(ex.Message);
        }
    }

    private void NumericInput_Click(object sender, EventArgs e)
    {
        if (sender is not NumericUpDown numeric)
        {
            return;
        }

        Action<AnalogTimerForm, int> propertyAccessor = numeric.Name switch
        {
            "HoursInput" => (form, value) => form.hours = value,
            "MinutesInput" => (form, value) => form.minutes = value,
            "SecondsInput" => (form, value) => form.seconds = value,
            _ => (form, value) => { }
        };

        try
        {
            propertyAccessor.Invoke(this, (int)numeric.Value);
        }
        catch(Exception ex)
        {
            DisplayError(ex.Message);
        }
    }

    private static DialogResult DisplayError(string error)
    {
        return MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    } 
}
