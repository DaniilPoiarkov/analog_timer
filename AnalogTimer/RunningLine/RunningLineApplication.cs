using ConsoleApplicationBuilder;
using ConsoleOutputEngine.Contracts;
using NLog;
using RunningLine.Contracts;
using RunningLine.Implementations.OutputFormatter;
using RunningLine.Prompts.Implementations;
using RunningLine.RunningLineDisplayHandlers;
using RunningLineEngine.Contracts;
using RunningLineEngine.Implementations;
using RunningLineEngine.Models;
using RunningLineEngine.Prompts.Implementations;

namespace RunningLine.ConsoleApplications;

internal class RunningLineApplication : ConsoleApplication<IRunningLine>
{
    private string Sentance { get; set; } = string.Empty;

    public RunningLineApplication()
    {
        var display = new DefaultDisplayHandler();

        Entity = new RunningLineEngine.Implementations.RunningLine(new RunningLineConfiguration());

        RunPrompt.NewSentence += (_, sentence) =>
        {
            Sentance = sentence;
            Entity.Set(IConsoleOutput.Create().GetLength(Sentance));
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
            .Add<CLosePromp>()
            .Build();
    }
}
