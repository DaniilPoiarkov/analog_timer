using MyTimer = AnalogTimer.Implementations.AnalogTimer;
using TimerEngine.Implementations.DisplayServices;
using AnalogTimer.Contracts;
using AnalogTimer.Implementations;
using AnalogTimer.Helpers;
using TimerEngine.Prompts.Implementations;
using ConsoleInterface.Contracts;
using ConsoleInterface.Prompts.Implementations;
using static WinApplication.Statics.Extensions;

namespace WinApplication;

public partial class AnalogTimerForm : Form
{
    private readonly MyTimer _timer;

    private readonly IPromptService<IAnalogTimer> _timerPromptService;

    private readonly IPromptService<IAnalogTimer> _stopwatchPromptService;

    public AnalogTimerForm()
    {
        InitializeComponent();

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
    }

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


    private async void PauseBtn_Click(object sender, EventArgs e)
    {
        //await UpdateTimerState(async timer => await timer.Stop());
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
        //UpdateTimerState(timer => timer.ResetState());
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
                //TickPerSecondInput.Value = 10;
                //SpeedChangedEvent(this, EventArgs.Empty);
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

    private void CutBtn_click(object sender, EventArgs e)
    {
        _timer.Cut();
    }

    private void StartBtnClick(object sender, EventArgs e)
    {

    }
}
