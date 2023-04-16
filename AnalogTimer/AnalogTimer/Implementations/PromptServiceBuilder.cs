using AnalogTimer.Contracts;

namespace AnalogTimer.Implementations;

public class PromptServiceBuilder
{
    private readonly AnalogTimer _timer;

    public PromptServiceBuilder(AnalogTimer timer)
    {
        _timer = timer;
    }

    private readonly List<IPrompt> _prompts = new();

    public PromptServiceBuilder Add<TPrompt>()
        where TPrompt : IPrompt, new()
    {
        _prompts.Add(new TPrompt());
        return this;
    }

    public IPromptService Build() => new PromptService(_prompts, _timer);
}
