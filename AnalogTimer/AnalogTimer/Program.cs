using AnalogTimer.Implementations;
using AnalogTimer.Prompts.Implementations;

var timer = new AnalogTimer.Implementations.AnalogTimer();

var prompts = new PromptCollectionBuilder()
    .Add<StartPrompt>()
    .Add<PausePrompt>()
    .Add<ResetPrompt>()
    .Add<ResumePrompt>()
    .Add<AddSecondsPrompt>()
    .Add<AddMinutesPrompt>()
    .Add<AddHoursPrompt>()
    .Add<ChangeSpeedPrompt>()
    .Add<CloseTimerPrompt>()
    .Build();

var promptService = new PromptService(prompts, timer);

promptService.DisplayPrompts();

while (true)
{
    await promptService.Run();
}
