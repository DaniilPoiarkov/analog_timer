﻿using AnalogTimer.RunningLineDisplayHandlers;
using ConsoleInterface.Prompts.Implementations;
using RunningLineEngine.Contracts;
using RunningLineEngine.Implementations;
using RunningLineEngine.Prompts.Implementations;

namespace AnalogTimer.ConsoleApplications;

internal class RunningLineApplication : ConsoleApplication<IRunningLine>
{
    public RunningLineApplication()
    {
        Entity = new RunningLine(new DefaultDisplayHandler());
        PromptService = new RunningLinePromptServiceBuilder(Entity)
            .Add<ChangeSpeedPrompt<IRunningLine>>()
            .Add<PausePrompt<IRunningLine>>()
            .Add<CleanLinePrompt>()
            .Add<RunPrompt>()
            .Add<CLosePromp>()
            .Build();
    }
}