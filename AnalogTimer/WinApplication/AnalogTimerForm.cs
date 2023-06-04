using MyTimer = AnalogTimer.Implementations.AnalogTimer;
using TimerEngine.Implementations.DisplayServices;

namespace WinApplication;

public partial class AnalogTimerForm : Form
{
    private readonly MyTimer _timer;

    public AnalogTimerForm()
    {
        InitializeComponent();

        var displayService = new WinFormDisplayService(null, null);

        _timer = new MyTimer();

        _timer.Tick += displayService.DisplayTick;
        _timer.Updated += displayService.DisplayUpdated;
        _timer.TimerCut += displayService.DisplayCut;
        _timer.Stopeed += _ =>
        {
            SwitchControlsAccessability();
        };
    }

    private void SwitchControlsAccessability()
    {
        //StopwatchStartBtn.Enabled = !StopwatchStartBtn.Enabled;
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
        //if (!StopwatchConsoleInput.Enabled)
        //{
        //    StopwatchOpenConsoleBtn.Text = "Disable console mode";
        //    StopwatchConsoleInput.Enabled = true;
        //}
        //else
        //{
        //    StopwatchOpenConsoleBtn.Text = "Enable console mode";
        //    StopwatchConsoleInput.Enabled = false;
        //    StopwatchConsoleInput.Text = string.Empty;
        //}
    }

    //private bool NeedsSwitchButtonsAccessability()
    //{
    //    //var input = StopwatchConsoleInput.Text.ToLower();

    //    //return input.StartsWith("start");
    //}

    private void CutBtn_click(object sender, EventArgs e)
    {
        _timer.Cut();
    }

    private void StartBtnClick(object sender, EventArgs e)
    {

    }
}
