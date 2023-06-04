using AnalogTimer.Contracts;
using ConsoleInterface.Contracts;
using WinApplication.Implementations;
using AnalogTimer.Implementations;
using ConsoleInterface.Prompts.Implementations;
using TimerEngine.Prompts.Implementations;
using AnalogTimer.Helpers;
using static WinApplication.Statics.Extensions;
using MyTimer = AnalogTimer.Implementations.AnalogTimer;
using AnalogTimer.Models;
using WinApplication.ButtonStateEngine;
using WinApplication.ButtonStateEngine.LeftButtonStates;

namespace WinApplication;

public partial class AnalogTimerControl : UserControl
{
    private readonly MyTimer _timer;

    private readonly IPromptService<IAnalogTimer> _timerPromptService;

    private ButtonsStateBase _switchStateBtnState;


    private int hours;

    private int minutes;

    private int seconds;

    public AnalogTimerControl()
    {
        InitializeComponent();

        _timer = new MyTimer();

        var displayService = new TimerDisplayService(TimerOutput);

        _timer.Tick += displayService.DisplayTick;
        _timer.Updated += displayService.DisplayUpdated;
        _timer.Stopeed += _ =>
        {
            SwitchControlsAccessability();
        };

        MillisecondDisplayHelper.OutputHandler += (_, digit) =>
        {
            SetMillisecond(digit.ToString());
        };

        _timerPromptService = new AnalogTimerPromptServiceBuilder(_timer)
            .Add<StartPrompt>()
            .Add<PausePrompt<IAnalogTimer>>()
            .Add<ResetPrompt>()
            .Add<AddSecondsPrompt>()
            .Add<AddMinutesPrompt>()
            .Add<AddHoursPrompt>()
            .Add<ChangeSpeedPrompt<IAnalogTimer>>()
            .Build();

        _switchStateBtnState = new StartButtonState(SwitchTimerBtn, TimerCaancelBtn);
        SubscribeToButtons();
    }

    private void SubscribeToButtons()
    {
        _switchStateBtnState.StartPressed += (_, _) =>
        {
            _timer.Start();
        };

        _switchStateBtnState.PausePressed += async (_, _) =>
        {
            await _timer.Stop();
        };

        _switchStateBtnState.ResumePressed += (_, _) =>
        {
            _timer.Start();
        };

        _switchStateBtnState.CancelPressed += (_, _) =>
        {
            _timer.ResetState();
            _switchStateBtnState = new StartButtonState(SwitchTimerBtn, TimerCaancelBtn);
            SubscribeToButtons();
        };
    }

    private void SetMillisecond(string digit)
    {
        if (TimerMsOutput.InvokeRequired)
        {
            var setMillisecond = new SetMillisecondCallback(SetMillisecond);
            Invoke(setMillisecond, digit);
        }
        else
        {
            TimerMsOutput.Text = digit;
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

    private void SpeedChangedEvent(object sender, EventArgs e)
    {
        var speedCoef = (int)TickPerSecondInput.Value;
        UpdateTimerState(timer => timer.ChangeSpeed(speedCoef));
    }

    private void NumericInput_Click(object sender, EventArgs e)
    {
        if (sender is not NumericUpDown numeric)
        {
            return;
        }

        Action<AnalogTimerControl, int> propertyChanger = numeric.Name switch
        {
            "HoursInput" => (control, value) => control.hours = value,
            "MinutesInput" => (control, value) => control.minutes = value,
            "SecondsInput" => (control, value) => control.seconds = value,
            _ => (control, value) => { throw new Exception("Something going wrong, try again."); }
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

    private async void ConsoleInputEnterKeydown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode != Keys.Enter)
        {
            return;
        }

        try
        {
            await _timerPromptService.Consume(TimerConsoleInput.Text);

            if (NeedsSwitchButtonsAccessability())
            {
                SwitchControlsAccessability();
            }

            if (TimerConsoleInput.Text.StartsWith("speed") && _timer.TicksPerSecond > 10)
            {
                TickPerSecondInput.Value = 10;
                SpeedChangedEvent(this, EventArgs.Empty);
            }

            TimerConsoleInput.Text = string.Empty;
        }
        catch (Exception ex)
        {
            DisplayError(ex.Message);
        }
    }

    private bool NeedsSwitchButtonsAccessability()
    {
        var input = TimerConsoleInput.Text.ToLower();

        return input.StartsWith("start");
    }

    private void SwitchControlsAccessability()
    {
        //StopwatchStartBtn.Enabled = !StopwatchStartBtn.Enabled;
        //PauseBtn.Enabled = !PauseBtn.Enabled;
        //ResetBtn.Enabled = !ResetBtn.Enabled;
        //ChangeSpeedInput.Enabled = !ChangeSpeedInput.Enabled;
    }

    protected void UpdateTimerState(Action<MyTimer> action, Action? onSuccess = null)
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

    protected async Task UpdateTimerState(Func<MyTimer, Task> action, Action? onSuccess = null)
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

    private void SwitchTimerStateBtnClick(object sender, EventArgs e)
    {
        if (sender is not Button switchBtn)
        {
            return;
        }

        _switchStateBtnState.LeftBtnClick();

        _switchStateBtnState = switchBtn.Text switch
        {
            "Start" => new StartButtonState(SwitchTimerBtn, TimerCaancelBtn),
            "Resume" => new ResumeButtonState(SwitchTimerBtn, TimerCaancelBtn),
            "Pause" => new PauseButtonState(SwitchTimerBtn, TimerCaancelBtn),
            _ => new StartButtonState(SwitchTimerBtn, TimerCaancelBtn),
        };

        SubscribeToButtons();
    }

    private void CancelBtnClick(object sender, EventArgs e)
    {
        _switchStateBtnState.RightBtnClick();
    }
}
