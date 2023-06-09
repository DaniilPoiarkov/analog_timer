using ConsoleApplicationBuilder.Prompts;
using RunningLineEngine.Contracts;

namespace RunningLineEngine.Implementations;

public class RunningLinePromptServiceBuilder : PromptServiceBuilder<IRunningLine>
{
    public RunningLinePromptServiceBuilder(IRunningLine entity) : base(entity)
    {
    }
}
