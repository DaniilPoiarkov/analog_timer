using WinApplication.Implementations;
using static WinApplication.Statics.Helper;
using MyTimer = AnalogTimer.Implementations.AnalogTimer;
using AnalogTimer.Models;
using WinApplication.ButtonStateEngine;
using WinApplication.ButtonStateEngine.TimerButtonStates;
using TimerEngine.Models.Enums;

namespace WinApplication;

public partial class AnalogTimerControl : UserControl
{
    private readonly MyTimer _timer;

    private ButtonsStateBase _switchStateBtnState;

    private readonly TimerDisplayService _timerDisplayService;


    private int hours;

    private int minutes;

    private int seconds;

    public AnalogTimerControl()
    {
        InitializeComponent();

        _timer = new MyTimer();
        _timer.SetTimerType(TimerType.Timer);

        _timerDisplayService = new TimerDisplayService(TimerOutput);

        SubscribeToTimer();

        _switchStateBtnState = new InitialButtonsState(SwitchTimerBtn, TimerCaancelBtn);
        SubscribeToButtons();
    }

    #region Subscribtions

    private void SubscribeToButtons()
    {
        _switchStateBtnState.StartPressed += (_, _) =>
        {
            var state = new TimerState(hours, minutes, seconds, 0);

            if (!state.IsZero)
            {
                _timer.ResetState();
                _timer.AddHours(state.Hours);
                _timer.AddMinutes(state.Minutes);
                _timer.AddSeconds(state.Seconds);
            }

            UpdateTimerState(timer =>
            {
                timer.Start();

                _switchStateBtnState = new StartButtonState(SwitchTimerBtn, TimerCaancelBtn);
                SubscribeToButtons();
                ResetFormValues(false);
            });
        };

        _switchStateBtnState.PausePressed += async (_, _) =>
        {
            await UpdateTimerState(async timer =>
            {
                await timer.Stop();

                _switchStateBtnState = new PauseButtonState(SwitchTimerBtn, TimerCaancelBtn);
                SubscribeToButtons();
                ResetFormValues(false);
            });
        };

        _switchStateBtnState.ResumePressed += (_, _) =>
        {
            UpdateTimerState(timer =>
            {
                timer.Start();

                _switchStateBtnState = new ResumeButtonState(SwitchTimerBtn, TimerCaancelBtn);
                SubscribeToButtons();
            });
        };

        _switchStateBtnState.CancelPressed += (_, _) =>
        {
            UpdateTimerState(timer =>
            {
                timer.ResetState();

                _switchStateBtnState = new InitialButtonsState(SwitchTimerBtn, TimerCaancelBtn);
                SubscribeToButtons();

                HoursInput.Value = 0;
                MinutesInput.Value = 0;
                SecondsInput.Value = 0;
                TimerMsOutput.Text = "0";
                TickPerSecondInput.Value = 1;

                ResetFormValues(true);
            });
        };
    }

    private void SubscribeToTimer()
    {
        _timer.Tick += _timerDisplayService.DisplayTick;
        _timer.Updated += _timerDisplayService.DisplayUpdated;
        _timer.Stopeed += args =>
        {
            _switchStateBtnState = new InitialButtonsState(SwitchTimerBtn, TimerCaancelBtn);
            SubscribeToButtons();
            ResetFormValues(true);
        };

        _timer.MillisecondDisplayHelper.OutputHandler += (_, digit) =>
        {
            SetMillisecond(digit.ToString());
        };
    }

    #endregion

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

    private void SwitchTimerStateBtnClick(object sender, EventArgs e)
    {
        if (sender is not Button switchBtn)
        {
            return;
        }

        UpdateTimerState(_ => _switchStateBtnState.LeftBtnClick());
    }

    private void CancelBtnClick(object sender, EventArgs e)
    {
        UpdateTimerState(_ => _switchStateBtnState.RightBtnClick());
    }

    private void StartFiveMinutesBtnClick(object sender, EventArgs e)
    {
        UpdateTimerState(timer =>
        {
            _switchStateBtnState = new InitialButtonsState(SwitchTimerBtn, TimerCaancelBtn);
            SubscribeToButtons();
            ResetFormValues(true);

            HoursInput.Value = hours = 0;
            MinutesInput.Value = minutes = 5;
            SecondsInput.Value = seconds = 0;

            _switchStateBtnState.LeftBtnClick();
        });
    }

    private void StartTenSecondsBtnClick(object sender, EventArgs e)
    {
        UpdateTimerState(timer =>
        {
            _switchStateBtnState = new InitialButtonsState(SwitchTimerBtn, TimerCaancelBtn);
            SubscribeToButtons();
            ResetFormValues(true);

            HoursInput.Value = hours = 0;
            MinutesInput.Value = minutes = 0;
            SecondsInput.Value = seconds = 10;

            _switchStateBtnState.LeftBtnClick();
        });
    }

    private void ResetFormValues(bool accessability)
    {
        HoursInput.Enabled = accessability;
        MinutesInput.Enabled = accessability;
        SecondsInput.Enabled = accessability;

        TimerStartFiveMinBtn.Enabled = accessability;
        TimerStartTenSecBtn.Enabled = accessability;

        TickPerSecondInput.Enabled = accessability;
    }

    protected void UpdateTimerState(Action<MyTimer> action)
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

    protected async Task UpdateTimerState(Func<MyTimer, Task> action)
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
}
