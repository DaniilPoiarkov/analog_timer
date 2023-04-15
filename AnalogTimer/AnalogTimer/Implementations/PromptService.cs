using AnalogTimer.Contracts;

namespace AnalogTimer.Implementations;

public class PromptService : IPromptService
{
    private readonly IEnumerable<IPrompt> _prompts;

    private readonly AnalogTimer _analogTimer;

    private const int _exceptionLine = 8;
    
    private const int _inputLine = 9;

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
        Console.CursorTop = _inputLine;
        var input = Console.ReadLine();
        Console.CursorTop = _inputLine;
        Console.WriteLine(new string(' ', Console.BufferWidth));

        var values = input?
            .TrimEnd()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(v => v.ToLower())
            .ToList();

        if (values is null || !values.Any())
        {
            Console.CursorTop = _exceptionLine;
            Console.WriteLine("Exception: Invalid input");
            return;
        }

        var prompt = _prompts.FirstOrDefault(p => p.Name.ToLower().Equals(values[0]?.ToLower()));

        if(prompt is null)
        {
            Console.CursorTop = _exceptionLine;
            Console.WriteLine($"Prompt with name \'{values[0]}\' not found");
            return;
        }

        try
        {
            await prompt.Proceed(input, _analogTimer);
        }
        catch (Exception ex)
        {
            Console.CursorTop = _exceptionLine;
            Console.WriteLine(new string(' ', Console.BufferWidth));
            
            Console.CursorTop = _exceptionLine;
            Console.WriteLine($"Exception: {ex.Message}");
        }
    }
}
