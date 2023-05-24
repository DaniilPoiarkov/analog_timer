namespace AnalogTimer.Contracts;

public interface IPromptService
{
    IReadOnlyCollection<IAnalogTimerPrompt> Prompts { get; }

    Task Consume(string? input);
}
