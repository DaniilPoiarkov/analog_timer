using AnalogTimer.Implementations;
using AnalogTimer.Prompts.Implementations;

var timer = new AnalogTimer.Implementations.AnalogTimer();

var promptService = new PromptServiceBuilder(timer)
    .Add<StartPrompt>()
    .Add<PausePrompt>()
    .Add<ResetPrompt>()
    .Add<AddSecondsPrompt>()
    .Add<AddMinutesPrompt>()
    .Add<AddHoursPrompt>()
    .Add<ChangeSpeedPrompt>()
    .Add<ChangeTimerTypePrompt>()
    .Add<CloseTimerPrompt>()
    .Build();

promptService.DisplayPrompts();

while (true)
{
    await promptService.Run();
}
