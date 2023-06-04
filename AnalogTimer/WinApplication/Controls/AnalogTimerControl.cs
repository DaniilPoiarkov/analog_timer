﻿using AnalogTimer.Contracts;
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
using TimerEngine.Models.Enums;

namespace WinApplication;

public partial class AnalogTimerControl : UserControl
{
    private readonly MyTimer _timer;

    private readonly IPromptService<IAnalogTimer> _timerPromptService;

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

        _timerPromptService = new AnalogTimerPromptServiceBuilder(_timer)
            .Add<StartPrompt>()
            .Add<PausePrompt<IAnalogTimer>>()
            .Add<ResetPrompt>()
            .Add<AddSecondsPrompt>()
            .Add<AddMinutesPrompt>()
            .Add<AddHoursPrompt>()
            .Add<ChangeSpeedPrompt<IAnalogTimer>>()
            .Build();

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

            _timer.Start();

            _switchStateBtnState = new StartButtonState(SwitchTimerBtn, TimerCaancelBtn);
            SubscribeToButtons();
            ResetFormValues(false);
        };

        _switchStateBtnState.PausePressed += async (_, _) =>
        {
            await _timer.Stop();

            _switchStateBtnState = new PauseButtonState(SwitchTimerBtn, TimerCaancelBtn);
            SubscribeToButtons();
        };

        _switchStateBtnState.ResumePressed += (_, _) =>
        {
            _timer.Start();

            _switchStateBtnState = new ResumeButtonState(SwitchTimerBtn, TimerCaancelBtn);
            SubscribeToButtons();
        };

        _switchStateBtnState.CancelPressed += (_, _) =>
        {
            _timer.ResetState();

            _switchStateBtnState = new InitialButtonsState(SwitchTimerBtn, TimerCaancelBtn);
            SubscribeToButtons();

            HoursInput.Value = 0;
            MinutesInput.Value = 0;
            SecondsInput.Value = 0;
            TickPerSecondInput.Value = 1;

            ResetFormValues(true);
        };
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

    private void SubscribeToTimer()
    {
        _timer.Tick += _timerDisplayService.DisplayTick;
        _timer.Updated += _timerDisplayService.DisplayUpdated;
        _timer.Stopeed += _ =>
        {
            _switchStateBtnState = new InitialButtonsState(SwitchTimerBtn, TimerCaancelBtn);
            ResetFormValues(true);
        };

        MillisecondDisplayHelper.OutputHandler += (_, digit) =>
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

    private async void ConsoleInputEnterKeydown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode != Keys.Enter)
        {
            return;
        }

        try
        {
            await _timerPromptService.Consume(TimerConsoleInput.Text);

            UpdateSwitchButtonsAccessability();

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

    private void UpdateSwitchButtonsAccessability()
    {
        var userInput = TimerConsoleInput.Text.ToLower();

        string btnText = string.Empty;

        if (userInput.StartsWith("start"))
        {
            _switchStateBtnState = new StartButtonState(SwitchTimerBtn, TimerCaancelBtn);
            SubscribeToButtons();
        }
        else if (userInput.StartsWith("pause") || userInput.StartsWith("-p"))
        {
            _switchStateBtnState = new PauseButtonState(SwitchTimerBtn, TimerCaancelBtn);
            SubscribeToButtons();
        }
        else if (userInput.StartsWith("reset") || userInput.StartsWith("-r"))
        {
            _switchStateBtnState = new InitialButtonsState(SwitchTimerBtn, TimerCaancelBtn);
            SubscribeToButtons();
            ResetFormValues(true);

            HoursInput.Value = 0;
            MinutesInput.Value = 0;
            SecondsInput.Value = 0;
            TickPerSecondInput.Value = 1;

        }

        if (!string.IsNullOrEmpty(btnText))
        {
            SwitchTimerBtn.Text = btnText;
        }
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
        _switchStateBtnState.RightBtnClick();
    }

    private void StartFiveMinutesBtnClick(object sender, EventArgs e)
    {
        UpdateTimerState(timer =>
        {
            timer.ResetState();
            timer.AddMinutes(5);

            _switchStateBtnState.LeftBtnClick();
        });
    }

    private void StartTenSecondsBtnClick(object sender, EventArgs e)
    {
        UpdateTimerState(timer =>
        {
            timer.ResetState();
            timer.AddSeconds(10);

            _switchStateBtnState.LeftBtnClick();
        });
    }

    private void SwitchConsoleAccessability(object sender, EventArgs e)
    {
        if (TimerConsoleInput.Enabled)
        {
            TimerConsoleInput.Enabled = false;
            TimerConsoleInput.Text = string.Empty;
            TimerOpenConsoleBtn.Text = "Enable console";
        }
        else
        {
            TimerConsoleInput.Enabled = true;
            TimerOpenConsoleBtn.Text = "Disable console";
        }
    }
}
