namespace AnalogTimer.Contracts;

public interface IPromptService
{
    IReadOnlyCollection<IPrompt> Prompts { get; }

    Task Consume(string input);
}
