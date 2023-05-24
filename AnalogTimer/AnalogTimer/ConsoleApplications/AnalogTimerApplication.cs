using AnalogTimer.Contracts;
using AnalogTimer.Implementations;
using ConsoleInterface.EntityImplementations;
using ConsoleInterface.Contracts;
using TimerEngine.Prompts.Implementations;

namespace AnalogTimer.ConsoleApplications;

internal class AnalogTimerApplication : ConsoleApplication
{
    private readonly IPromptService<IAnalogTimer> _promptService;

    public AnalogTimerApplication()
    {
        var displayService = new ConsoleDisplayService(new DefaultTemplate());
        var timer = new Implementations.AnalogTimer();

        timer.Tick += displayService.DisplayTick;
        timer.Updated += displayService.DisplayUpdated;
        timer.TimerCut += displayService.DisplayCut;

        _promptService = new AnalogTimerPromptServiceBuilder(timer)
            .Add<StartPrompt>()
            .Add<PausePrompt>()
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

    protected override void DisplayInstruction()
    {
        Console.CursorTop = 12;

        foreach (var prompt in _promptService.Prompts)
        {
            Console.WriteLine(prompt.Instruction);
        }
    }

    protected override async Task HandleUserInput(string? input)
    {
        await _promptService.Consume(input);
    }
}
