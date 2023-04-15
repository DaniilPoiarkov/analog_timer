using AnalogTimer.Contracts;

namespace AnalogTimer.Implementations;

public class PromptService : IPromptService
{
    private readonly IEnumerable<IPrompt> _prompts;

    private readonly AnalogTimer _analogTimer;

    public PromptService(
        IEnumerable<IPrompt> prompts,
        AnalogTimer analogTimer)
    {
        _prompts = prompts;
        _analogTimer = analogTimer;
    }

    public void DisplayPrompts()
    {
        Console.CursorTop = 12;

        foreach (var prompt in _prompts)
        {
            Console.WriteLine(prompt.Instruction);
        }
    }

    public async Task Run()
    {
        DisplayPrompts();

        var input = Console.ReadLine();

        var values = input?
            .TrimEnd()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(v => v.ToLower())
            .ToList();

        Console.CursorTop = 12;

        foreach(var instruction in _prompts.Select(p => p.Instruction))
        {
            Console.WriteLine(new string(' ', instruction.Length));
        }

        if (values is null || !values.Any())
        {
            Console.WriteLine("Invalid input");
            return;
        }

        var prompt = _prompts.FirstOrDefault(p => p.Name.ToLower().Equals(values[0]?.ToLower()));

        if(prompt is null)
        {
            Console.WriteLine($"Prompt with name \'{values[0]}\' not found");
            return;
        }

        await prompt.Proceed(input, _analogTimer);
    }
}
    