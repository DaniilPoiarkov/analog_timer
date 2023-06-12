using ConsoleApplicationBuilder.Contracts;

namespace ConsoleApplicationBuilder.Prompts;

public class PromptServiceBuilder<TEntity>
{
    private readonly TEntity _entity;

    public PromptServiceBuilder(TEntity entity)
    {
        _entity = entity;
    }

    private readonly List<IPrompt<TEntity>> _prompts = new();

    public PromptServiceBuilder<TEntity> Add<TPrompt>()
        where TPrompt : IPrompt<TEntity>, new()
    {
        _prompts.Add(new TPrompt());
        return this;
    }

    public IPromptService<TEntity> Build() => new PromptService<TEntity>(_prompts, _entity);
}
