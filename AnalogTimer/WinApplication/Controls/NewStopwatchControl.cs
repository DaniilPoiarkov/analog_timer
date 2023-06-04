using MyTimer = AnalogTimer.Implementations.AnalogTimer;
using static WinApplication.Statics.Extensions;
using AnalogTimer.Contracts;
using AnalogTimer.Implementations;
using ConsoleInterface.Contracts;
using ConsoleInterface.Prompts.Implementations;
using TimerEngine.Prompts.Implementations;
using TimerEngine.Implementations.DisplayServices;

namespace WinApplication;

public partial class NewStopwatchControl : UserControl
{
    private readonly MyTimer _timer;

    private readonly IPromptService<IAnalogTimer> _stopwatchPromptService;

    public NewStopwatchControl()
    {
        InitializeComponent();

        _timer = new MyTimer();

        var displayService = new WinFormDisplayService(StopwatchOutput, cutOutput);

        _timer.Tick += displayService.DisplayTick;
        _timer.Updated += displayService.DisplayUpdated;
        _timer.TimerCut += displayService.DisplayCut;
        _timer.Stopeed += _ =>
        {

        };

        _stopwatchPromptService = new AnalogTimerPromptServiceBuilder(_timer)
            .Add<StartPrompt>()
            .Add<PausePrompt<IAnalogTimer>>()
            .Add<ResetPrompt>()
            .Add<CutTimerStatePrompt>()
            .Build();
    }

    private void SwitchConsoleAccessability(object sender, EventArgs e)
    {
        if (StopwatchConsoleInput.Enabled)
        {
            StopwatchConsoleInput.Enabled = false;
            StopwatchConsoleInput.Text = string.Empty;
            StopwatchOpenConsoleBtn.Text = "Enable console";
        }
        else
        {
            StopwatchConsoleInput.Enabled = true;
            StopwatchOpenConsoleBtn.Text = "Disable console";
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
}
