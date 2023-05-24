using AnalogTimer.Contracts;
using AnalogTimer.Implementations;
using TimerEngine.Prompts.Implementations;
using ConsoleInterface.Prompts.Implementations;

namespace AnalogTimer.ConsoleApplications;

internal class AnalogTimerApplication : ConsoleApplication<IAnalogTimer>
{
    public AnalogTimerApplication()
    {
        var displayService = new ConsoleDisplayService(new DefaultTemplate());
        Entity = new Implementations.AnalogTimer();

        Entity.Tick += displayService.DisplayTick;
        Entity.Updated += displayService.DisplayUpdated;
        Entity.TimerCut += displayService.DisplayCut;

        PromptService = new AnalogTimerPromptServiceBuilder(Entity)
            .Add<StartPrompt>()
            .Add<PausePrompt<IAnalogTimer>>()
            .Add<ResetPrompt>()
            .Add<AddSecondsPrompt>()
            .Add<AddMinutesPrompt>()
            .Add<AddHoursPrompt>()
            .Add<ChangeSpeedPrompt<IAnalogTimer>>()
            .Add<ChangeTimerTypePrompt>()
            .Add<CloseTimerPrompt>()
            .Add<CutTimerStatePrompt>()
            .Build();
    }
}
