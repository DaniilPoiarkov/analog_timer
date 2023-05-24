using AnalogTimer.Contracts;

namespace AnalogTimer.Implementations;

public class PromptService : IPromptService
{
    private readonly IEnumerable<IPrompt> _prompts;

    private readonly IAnalogTimer _analogTimer;

    public IReadOnlyCollection<IPrompt> Prompts => _prompts.ToList();

    public PromptService(
        IEnumerable<IPrompt> prompts,
        IAnalogTimer analogTimer)
    {
        _prompts = prompts;
        _analogTimer = analogTimer;
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

        await prompt.Proceed(input, _analogTimer);
    }
}
