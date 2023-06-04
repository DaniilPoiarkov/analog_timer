using MyTimer = AnalogTimer.Implementations.AnalogTimer;
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
            SwitchControlsAccessability();
        };

        _stopwatchPromptService = new AnalogTimerPromptServiceBuilder(_timer)
            .Add<StartPrompt>()
            .Add<PausePrompt<IAnalogTimer>>()
            .Add<ResetPrompt>()
            .Add<CutTimerStatePrompt>()
            .Build();
    }

    private void SwitchControlsAccessability()
    {
        //StopwatchStartBtn.Enabled = !StopwatchStartBtn.Enabled;
        //PauseBtn.Enabled = !PauseBtn.Enabled;
        //ResetBtn.Enabled = !ResetBtn.Enabled;
        //ChangeSpeedInput.Enabled = !ChangeSpeedInput.Enabled;
    }
}
