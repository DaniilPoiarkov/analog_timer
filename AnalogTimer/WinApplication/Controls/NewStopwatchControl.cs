using MyTimer = AnalogTimer.Implementations.AnalogTimer;
using static WinApplication.Statics.Helper;
using WinApplication.ButtonStateEngine;
using WinApplication.ButtonStateEngine.StopwatchButtonStates;
using WinApplication.Implementations;

namespace WinApplication;

public partial class NewStopwatchControl : UserControl
{
    private readonly MyTimer _timer;

    private readonly StopwatchDisplayService _stopwatchDisplayService;

    private ButtonsStateBase _buttonState;

    public NewStopwatchControl()
    {
        InitializeComponent();

        _timer = new MyTimer();
        _stopwatchDisplayService = new StopwatchDisplayService(StopwatchOutput, cutOutput);
        _buttonState = new InitialButtonState(StopwatchStartBtn, StopwatchResetBtn);

        SubscribeToTimer();
        SubscribeToButtons();
    }

    #region Subscribtions

    private void SubscribeToButtons()
    {
        _buttonState.StartPressed += (_, _) =>
        {
            UpdateTimerState(timer =>
            {
                timer.Start();

                _buttonState = new StartStopwatchState(StopwatchStartBtn, StopwatchResetBtn);
                SubscribeToButtons();
            });
        };

        _buttonState.PausePressed += async (_, _) =>
        {
            await UpdateTimerState(async timer =>
            {
                await timer.Stop();

                _buttonState = new PauseStopwatchState(StopwatchStartBtn, StopwatchResetBtn);
                SubscribeToButtons();
            });
        };

        _buttonState.ResumePressed += (_, _) =>
        {
            UpdateTimerState(timer =>
            {
                timer.Start();

                _buttonState = new StartStopwatchState(StopwatchStartBtn, StopwatchResetBtn);
                SubscribeToButtons();
            });
        };

        _buttonState.CancelPressed += (_, _) =>
        {
            UpdateTimerState(timer =>
            {
                timer.ResetState();

                _buttonState = new InitialButtonState(StopwatchStartBtn, StopwatchResetBtn);
                cutOutput.Text = string.Empty;
                StopwatchMsOutput.Text = "0";
                SubscribeToButtons();
            });
        };

        _buttonState.CutPressed += (_, _) =>
        {
            _timer.Cut();
        };
    }

    private void SubscribeToTimer()
    {
        _timer.Tick += _stopwatchDisplayService.DisplayTick;
        _timer.Updated += _stopwatchDisplayService.DisplayUpdated;
        _timer.TimerCut += _stopwatchDisplayService.DisplayCut;

        _timer.Stopeed += _ =>
        {
            _buttonState = new InitialButtonState(StopwatchStartBtn, StopwatchResetBtn);
            SubscribeToButtons();

            if (_timer.GetSnapshot().IsZero)
            {
                StopwatchMsOutput.Text = "0";
            }
        };

        _timer.MillisecondDisplayHelper.OutputHandler += (_, digit) =>
        {
            SetMillisecond(digit.ToString());
        };
    }

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

    private void SwitchStopwatchClick(object sender, EventArgs e)
    {
        _buttonState.LeftBtnClick();
    }

    private void RightBtnCLick(object sender, EventArgs e)
    {
        _buttonState.RightBtnClick();
    }
}
