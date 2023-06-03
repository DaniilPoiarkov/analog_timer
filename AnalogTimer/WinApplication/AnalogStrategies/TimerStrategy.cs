using AnalogTimer.Contracts;
using MyTimer = AnalogTimer.Implementations.AnalogTimer;
using AnalogTimer.Implementations;
using ConsoleInterface.Contracts;
using ConsoleInterface.Prompts.Implementations;
using TimerEngine.Prompts.Implementations;
using WinApplication.Contracts;
using AnalogTimer.Models;

namespace WinApplication.AnalogStrategies;

internal class TimerStrategy : IAnalogStrategy
{
    private readonly MyTimer _timer;

    private readonly AnalogTimerForm _timerForm;

    private readonly IPromptService<IAnalogTimer> _timerPromptService;

    private int hours;

    private int minutes;

    private int seconds;

    public TimerStrategy(AnalogTimerForm timerForm)
    {
        _timerForm = timerForm;

        _timer = new MyTimer();

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

    public void HandleStart()
    {
        var state = new TimerState(hours, minutes, seconds, 0);

        if (!state.IsZero)
        {
            _timer.ResetState();
            _timer.AddHours(state.Hours);
            _timer.AddMinutes(state.Minutes);
            _timer.AddSeconds(state.Seconds);

            //HoursInput.Value = 0;
            //MinutesInput.Value = 0;
            //SecondsInput.Value = 0;

            //NumericInput_Click(HoursInput, new());
            //NumericInput_Click(MinutesInput, new());
            //NumericInput_Click(SecondsInput, new());
        }

        //UpdateTimerState(timer => timer.Start(), SwitchControlsAccessability);
    }
}
