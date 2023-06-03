using AnalogTimer.Contracts;
using ConsoleInterface.Contracts;
using WinApplication.Implementations;
using AnalogTimer.Implementations;
using ConsoleInterface.Prompts.Implementations;
using TimerEngine.Prompts.Implementations;
using AnalogTimer.Helpers;
using static WinApplication.Statics.Extensions;
using AnalogTimer.Models;

namespace WinApplication;

public partial class AnalogTimerControl : AnalogControlBase
{
    private readonly IPromptService<IAnalogTimer> _timerPromptService;


    private int hours;

    private int minutes;

    private int seconds;

    public AnalogTimerControl()
    {
        InitializeComponent();

        var displayService = new TimerDisplayService(TimerOutput);

        Timer.Tick += displayService.DisplayTick;
        Timer.Updated += displayService.DisplayUpdated;
        Timer.Stopeed += _ =>
        {
            //SwitchControlsAccessability();
        };

        MillisecondDisplayHelper.OutputHandler += (_, digit) =>
        {
            SetMillisecond(digit.ToString());
        };

        _timerPromptService = new AnalogTimerPromptServiceBuilder(Timer)
            .Add<StartPrompt>()
            .Add<PausePrompt<IAnalogTimer>>()
            .Add<ResetPrompt>()
            .Add<AddSecondsPrompt>()
            .Add<AddMinutesPrompt>()
            .Add<AddHoursPrompt>()
            .Add<ChangeSpeedPrompt<IAnalogTimer>>()
            .Build();
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
            Timer.ResetState();
            Timer.AddHours(state.Hours);
            Timer.AddMinutes(state.Minutes);
            Timer.AddSeconds(state.Seconds);

            HoursInput.Value = 0;
            MinutesInput.Value = 0;
            SecondsInput.Value = 0;

            NumericInput_Click(HoursInput, new());
            NumericInput_Click(MinutesInput, new());
            NumericInput_Click(SecondsInput, new());
        }

        UpdateTimerState(timer => timer.Start()/*SwitchControlsAccessability*/);
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
}
