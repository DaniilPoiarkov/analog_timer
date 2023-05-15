namespace AnalogTimer.Contracts;

public interface IPromptService
{
    void DisplayPrompts();

    Task Run();

    Task Consume(string input);
}
