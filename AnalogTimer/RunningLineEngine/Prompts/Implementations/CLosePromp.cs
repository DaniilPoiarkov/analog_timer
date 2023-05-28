using RunningLineEngine.Contracts;

namespace RunningLineEngine.Prompts.Implementations;

public class CLosePromp : RunningLinePromptBase
{
    public override string Name => "close";

    public override string Instruction => "Write \'close\' to close an application.";

    public override string Shortcut => Name;

    public override Task Proceed(string input, IRunningLine entity)
    {
        Console.CursorTop += GetType().Assembly
            .GetTypes()
            .Where(t => t.IsAssignableTo(typeof(RunningLinePromptBase))
                && !t.IsAbstract
                && !t.IsInterface)
            .Count() + 5;

        Environment.Exit(0);

        return Task.CompletedTask;
    }
}
