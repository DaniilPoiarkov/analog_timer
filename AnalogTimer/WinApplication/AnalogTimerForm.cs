using MyTimer = AnalogTimer.Implementations.AnalogTimer;
using TimerEngine.Implementations.DisplayServices;
using AnalogTimer.Contracts;
using AnalogTimer.Models;
using AnalogTimer.Implementations;
using AnalogTimer.Helpers;
using TimerEngine.Prompts.Implementations;
using ConsoleInterface.Contracts;
using ConsoleInterface.Prompts.Implementations;
using WinApplication.Contracts;
using WinApplication.AnalogStrategies;
using TimerEngine.Models.Enums;

namespace WinApplication;

public partial class AnalogTimerForm : Form
{
    private readonly MyTimer _timer;

    private readonly IPromptService<IAnalogTimer> _timerPromptService;

    private readonly IPromptService<IAnalogTimer> _stopwatchPromptService;

    private IAnalogStrategy _strategy;



    delegate void SetMillisecondCallback(string text);

    private int hours;

    private int minutes;

    private int seconds;

    public AnalogTimerForm()
    {
        InitializeComponent();

        _strategy = new TimerStrategy(this);

        var displayService = new WinFormDisplayService(StopwatchOutput, cutOutput);

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

        _stopwatchPromptService = new AnalogTimerPromptServiceBuilder(_timer)
            .Add<StartPrompt>()
            .Add<PausePrompt<IAnalogTimer>>()
            .Add<ResetPrompt>()
            .Add<CutTimerStatePrompt>()
            .Build();

        _timerPromptService = new AnalogTimerPromptServiceBuilder(_timer)
            .Add<StartPrompt>()
            .Add<PausePrompt<IAnalogTimer>>()
            .Add<ResetPrompt>()
            .Add<AddSecondsPrompt>()
            .Add<AddMinutesPrompt>()
            .Add<AddHoursPrompt>()
            .Add<ChangeSpeedPrompt<IAnalogTimer>>()
            .Build();
    }

    #region Controls Methods

    #endregion

    #region Exposed for strategy methods

    #endregion


    private void SetMillisecond(string digit)
    {
        if (StopwatchMsOutput.InvokeRequired)
        {
            var setMillisecond = new SetMillisecondCallback(SetMillisecond);
            Invoke(setMillisecond, digit);
        }
        else
        {
            StopwatchMsOutput.Text = digit;
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
        StopwatchStartBtn.Enabled = !StopwatchStartBtn.Enabled;
        //PauseBtn.Enabled = !PauseBtn.Enabled;
        //ResetBtn.Enabled = !ResetBtn.Enabled;
        //ChangeSpeedInput.Enabled = !ChangeSpeedInput.Enabled;
    }

    private void ResetBtn_Click(object sender, EventArgs e)
    {
        UpdateTimerState(timer => timer.ResetState());
    }

    private void OpenConsoleBtn_Click(object sender, EventArgs e)
    {
        if (!StopwatchConsoleInput.Enabled)
        {
            StopwatchOpenConsoleBtn.Text = "Disable console mode";
            StopwatchConsoleInput.Enabled = true;
        }
        else
        {
            StopwatchOpenConsoleBtn.Text = "Enable console mode";
            StopwatchConsoleInput.Enabled = false;
            StopwatchConsoleInput.Text = string.Empty;
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
            await _timerPromptService.Consume(StopwatchConsoleInput.Text);

            if (NeedsSwitchButtonsAccessability())
            {
                SwitchControlsAccessability();
            }

            if (StopwatchConsoleInput.Text.StartsWith("speed") && _timer.TicksPerSecond > 10)
            {
                TickPerSecondInput.Value = 10;
                SpeedChangedEvent(this, EventArgs.Empty);
            }

            StopwatchConsoleInput.Text = string.Empty;
        }
        catch (Exception ex)
        {
            DisplayError(ex.Message);
        }
    }

    private bool NeedsSwitchButtonsAccessability()
    {
        var input = StopwatchConsoleInput.Text.ToLower();

        return input.StartsWith("start");
    }

    private void SpeedChangedEvent(object sender, EventArgs e)
    {
        var speedCoef = (int)TickPerSecondInput.Value;
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

    private void TabSelectClick(object sender, TabControlEventArgs e)
    {
        if (e.TabPage is null)
        {
            return;
        }

        var type = Enum.Parse<TimerType>(e.TabPage.Text);

        _strategy = type switch
        {
            TimerType.Timer => new TimerStrategy(this),
            TimerType.Stopwatch => new StopwatchStrategy(this),
            _ => throw new NotImplementedException(),
        };
    }

    private void StartBtnClick(object sender, EventArgs e)
    {
        _strategy.HandleStart();
    }
}
