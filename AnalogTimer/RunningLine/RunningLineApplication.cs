using ConsoleApplicationBuilder;
using RunningLine.Prompts.Implementations;
using RunningLineEngine.Contracts;
using RunningLineEngine.Implementations;
using RunningLineEngine.Models;
using RunningLineEngine.Prompts.Implementations;

namespace RunningLine.ConsoleApplications;

internal class RunningLineApplication : ConsoleApplication<IRunningLine>
{
    public RunningLineApplication()
    {
        Entity = new RunningLineEngine.Implementations.RunningLine(new RunningLineConfiguration());
        PromptService = new RunningLinePromptServiceBuilder(Entity)
            .Add<ChangeSpeedPrompt>()
            .Add<PausePrompt>()
            .Add<CleanLinePrompt>()
            .Add<RunPrompt>()
            .Add<CLosePromp>()
            .Build();
    }
}
