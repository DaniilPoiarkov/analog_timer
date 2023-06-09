using AnalogTimer.Contracts;
using AnalogTimer.Implementations;
using TimerEngine.Prompts.Implementations;
using ConsoleApplicationBuilder.Prompts.Implementations;
using ConsoleApplicationBuilder;

namespace AnalogTimer;

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
            .Add<PausePrompt>()
            .Add<ResetPrompt>()
            .Add<AddSecondsPrompt>()
            .Add<AddMinutesPrompt>()
            .Add<AddHoursPrompt>()
            .Add<ChangeSpeedPrompt>()
            .Add<ChangeTimerTypePrompt>()
            .Add<CloseTimerPrompt>()
            .Add<CutTimerStatePrompt>()
            .Build();
    }
}
