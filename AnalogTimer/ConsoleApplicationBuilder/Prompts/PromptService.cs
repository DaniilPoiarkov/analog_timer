using ConsoleApplicationBuilder.Contracts;

namespace ConsoleApplicationBuilder.Prompts;

public class PromptService<TEntity> : IPromptService<TEntity>
{
    private readonly IEnumerable<IPrompt<TEntity>> _prompts;

    private readonly TEntity _entity;

    public IReadOnlyCollection<IPrompt<TEntity>> Prompts => _prompts.ToList();

    public PromptService(
        IEnumerable<IPrompt<TEntity>> prompts,
        TEntity entity)
    {
        _prompts = prompts;
        _entity = entity;
    }

    public async Task Consume(string? input)
    {
        var values = input?
            .TrimEnd()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(v => v.ToLower())
            .ToList();

        if (values is null || !values.Any() || string.IsNullOrEmpty(input))
        {
            throw new Exception("Invalid input");
        }

        var prompt = _prompts.FirstOrDefault(p =>
                p.Name.ToLower().Equals(values[0])
             || p.Shortcut.ToLower().Equals(values[0]));

        if (prompt is null)
        {
            var name = values[0].StartsWith('-') ? "shortcut" : "name";

            throw new Exception($"Prompt with {name} \'{values[0]}\' not found",
                new Exception($"Input: \'{input}\', Values: {string.Join(' ', values)}"));
        }

        await prompt.Proceed(input, _entity);
    }
}
