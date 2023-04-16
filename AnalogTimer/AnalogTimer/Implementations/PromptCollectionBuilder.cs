using AnalogTimer.Contracts;

namespace AnalogTimer.Implementations;

public class PromptCollectionBuilder
{
    private readonly List<IPrompt> _prompts = new();

    public PromptCollectionBuilder Add<TPrompt>()
        where TPrompt : IPrompt, new()
    {
        _prompts.Add(new TPrompt());
        return this;
    }

    public IEnumerable<IPrompt> Build() => _prompts;
}
