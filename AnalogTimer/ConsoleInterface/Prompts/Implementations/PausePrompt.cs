using ConsoleInterface.Contracts;

namespace ConsoleInterface.Prompts.Implementations;

public class PausePrompt<TEntity> : IPrompt<TEntity>
    where TEntity : IAsyncRunnable
{
    public string Name => "pause";

    public string Shortcut => "-p";

    public string Instruction => "White \'pause\' or \'-p\' to pause.";

    public async Task Proceed(string input, TEntity entity)
    {
        await entity.Stop();
    }
}
