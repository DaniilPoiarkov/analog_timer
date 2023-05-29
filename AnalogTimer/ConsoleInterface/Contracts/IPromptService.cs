namespace ConsoleInterface.Contracts;

public interface IPromptService<TEntity>
{
    IReadOnlyCollection<IPrompt<TEntity>> Prompts { get; }

    Task Consume(string? input);
}
