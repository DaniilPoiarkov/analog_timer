﻿using ConsoleApplicationBuilder;
using RunningLine.Implementations;
using RunningLine.Prompts.Implementations;
using RunningLineEngine.Contracts;
using RunningLineEngine.Implementations;
using RunningLineEngine.Models;
using RunningLineEngine.Prompts.Implementations;
using MyRunningLine = RunningLineEngine.Implementations.RunningLine;

namespace RunningLine.ConsoleApplications;

internal class RunningLineApplication : ConsoleApplication<IRunningLine>
{
    private string Sentance { get; set; } = string.Empty;

    public RunningLineApplication()
    {
        Console.Title = "Running Line";

        var display = new DefaultDisplayHandler();

        Entity = new MyRunningLine(new RunningLineConfiguration());

        RunPrompt.NewSentence += (_, sentence) =>
        {
            var sentanceLength = display.GetLength(sentence);

            Entity.Set(sentanceLength);
            Sentance = sentence;
        };

        Entity.CleanEvent += (_, _) => display.Clean();
        Entity.Move += (_, args) =>
        {
            try
            {
                display.Display(Sentance, args);
            }
            catch(Exception ex)
            {
                _logger.Error(ex);
            }
        };

        PromptService = new RunningLinePromptServiceBuilder(Entity)
            .Add<ChangeSpeedPrompt>()
            .Add<PausePrompt>()
            .Add<CleanLinePrompt>()
            .Add<RunPrompt>()
            .Add<ClosePrompt>()
            .Build();
    }
}
