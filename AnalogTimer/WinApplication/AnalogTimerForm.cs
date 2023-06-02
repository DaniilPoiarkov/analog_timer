using MyTimer = AnalogTimer.Implementations.AnalogTimer;
using TimerEngine.Implementations.DisplayServices;
using AnalogTimer.Contracts;
using AnalogTimer.Models;
using AnalogTimer.Implementations;
using AnalogTimer.Helpers;
using TimerEngine.Prompts.Implementations;
using TimerEngine.Models.Enums;
using ConsoleInterface.Contracts;
using ConsoleInterface.Prompts.Implementations;

namespace WinApplication;

public partial class AnalogTimerForm : Form
{
    private readonly MyTimer _timer;

    private readonly IPromptService<IAnalogTimer> _promptService;

    delegate void SetMillisecondCallback(string text);

    private int hours;

    private int minutes;

    private int seconds;

    public AnalogTimerForm()
    {
        InitializeComponent();

        var displayService = new WinFormDisplayService(outputLabel, cutOutput);

        _timer = new MyTimer();

        _timer.Tick += displayService.DisplayTick;
        _timer.Updated += displayService.DisplayUpdated;
        _timer.TimerCut += displayService.DisplayCut;
        _timer.Stopeed += _ =>
        {
            SwitchControlsAccessability();
        };

        MillisecondDisplayHelper.OutputHandler += (_, digit) =>
        {
            SetMillisecond(digit.ToString());
        };

        _promptService = new AnalogTimerPromptServiceBuilder(_timer)
            .Add<StartPrompt>()
            .Add<PausePrompt<IAnalogTimer>>()
            .Add<ResetPrompt>()
            .Add<AddSecondsPrompt>()
            .Add<AddMinutesPrompt>()
            .Add<AddHoursPrompt>()
            .Add<ChangeSpeedPrompt<IAnalogTimer>>()
            .Add<ChangeTimerTypePrompt>()
            .Add<CutTimerStatePrompt>()
            .Build();

        TimerTypeComboBox.SelectedItem = Enum.GetName(TimerType.Stopwatch);
    }

    private void SetMillisecond(string digit)
    {
        if (millisecondsOutput.InvokeRequired)
        {
            var setMillisecond = new SetMillisecondCallback(SetMillisecond);
            Invoke(setMillisecond, digit);
        }
        else
        {
            millisecondsOutput.Text = digit;
        }
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

            NumericInput_Click(HoursInput, new());
            NumericInput_Click(MinutesInput, new());
            NumericInput_Click(SecondsInput, new());
        }

        UpdateTimerState(timer => timer.Start(), SwitchControlsAccessability);
    }

    private async void PauseBtn_Click(object sender, EventArgs e)
    {
        await UpdateTimerState(async timer => await timer.Stop());
    }

    private void SwitchControlsAccessability()
    {
        StartBtn.Enabled = !StartBtn.Enabled;
        PauseBtn.Enabled = !PauseBtn.Enabled;
        ResetBtn.Enabled = !ResetBtn.Enabled;
        TimerTypeComboBox.Enabled = !TimerTypeComboBox.Enabled;
        ChangeSpeedInput.Enabled = !ChangeSpeedInput.Enabled;
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
            var type = Enum.Parse<TimerType>(TimerTypeComboBox.SelectedItem.ToString()!);
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

            if (NeedsSwitchButtonsAccessability())
            {
                SwitchControlsAccessability();
            }

            TimerTypeComboBox.SelectedItem = Enum.GetName(_timer.Type);

            if (ConsoleInput.Text.StartsWith("speed") && _timer.TicksPerSecond > 10)
            {
                ChangeSpeedInput.Value = 10;
                SpeedChangedEvent(this, EventArgs.Empty);
            }

            ConsoleInput.Text = string.Empty;
        }
        catch (Exception ex)
        {
            DisplayError(ex.Message);
        }
    }

    private bool NeedsSwitchButtonsAccessability()
    {
        var input = ConsoleInput.Text.ToLower();

        return input.StartsWith("start");
    }

    private void SpeedChangedEvent(object sender, EventArgs e)
    {
        var speedCoef = (int)ChangeSpeedInput.Value;

        UpdateTimerState(timer => timer.ChangeSpeed(speedCoef));
    }

    private async Task UpdateTimerState(Func<MyTimer, Task> action, Action? onSuccess = null)
    {
        try
        {
            await action.Invoke(_timer);
            onSuccess?.Invoke();
        }
        catch (Exception ex)
        {
            DisplayError(ex.Message);
        }
    }

    private void UpdateTimerState(Action<MyTimer> action, Action? onSuccess = null)
    {
        try
        {
            action.Invoke(_timer);
            onSuccess?.Invoke();
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

        Action<AnalogTimerForm, int> propertyChanger = numeric.Name switch
        {
            "HoursInput" => (form, value) => form.hours = value,
            "MinutesInput" => (form, value) => form.minutes = value,
            "SecondsInput" => (form, value) => form.seconds = value,
            _ => (form, value) => { throw new Exception("Something going wrong, try again."); }
        };

        try
        {
            propertyChanger.Invoke(this, (int)numeric.Value);
        }
        catch (Exception ex)
        {
            DisplayError(ex.Message);
        }
    }

    private static DialogResult DisplayError(string error)
    {
        return MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private void CutBtn_click(object sender, EventArgs e)
    {
        _timer.Cut();
    }

    private void ClearOutputButton_Click(object sender, EventArgs e)
    {
        cutOutput.Text = string.Empty;
    }
}
