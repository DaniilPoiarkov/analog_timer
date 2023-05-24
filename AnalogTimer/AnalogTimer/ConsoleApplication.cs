using AnalogTimer.Helpers;
using ConsoleInterface.Contracts;
using NLog;

namespace AnalogTimer;

internal abstract class ConsoleApplication<TEntity>
{
    protected const int _inputLine = 9;

    protected const int _exceptionLine = 8;

    protected readonly Logger _logger = LogManager.GetCurrentClassLogger();

    protected IPromptService<TEntity>? PromptService;

    protected TEntity? Entity;

    protected static string GetUserInput()
    {
        Console.CursorTop = _inputLine;

        while (true)
        {
            var key = Console.ReadKey();

            if (key.Key == ConsoleKey.Enter)
                break;

            if (key.Key == ConsoleKey.Backspace)
            {
                UIHelper.RemoveLast();
                Console.CursorLeft = UIHelper.CursorPosition;
                Console.Write(' ');
                Console.CursorLeft = UIHelper.CursorPosition;
                continue;
            }

            if (!char.IsControl(key.KeyChar))
                UIHelper.Add(key.KeyChar);
        }

        return UIHelper.GetInput();
    }

    protected virtual void PrintException(string message, Exception? ex = null)
    {
        Console.CursorTop = _exceptionLine;
        Console.WriteLine(new string(' ', Console.WindowWidth));

        Console.CursorTop = _exceptionLine;
        Console.WriteLine($"Exception: {message}");
        _logger.Error(ex, message);
    }

    public virtual async Task Run()
    {
        if (PromptService is null || Entity is null)
        {
            throw new InvalidOperationException();
        }

        DisplayInstruction();

        while (true)
        {
            try
            {
                string? input = GetUserInput();
                Console.CursorTop = _inputLine;
                Console.WriteLine(new string(' ', Console.BufferWidth));
                await HandleUserInput(input);
            }
            catch (Exception ex)
            {
                lock (this)
                {
                    PrintException(ex.Message, ex);
                }
            }
        }
    }

    protected virtual async Task HandleUserInput(string input)
    {
        await PromptService!.Consume(input);
    }

    protected virtual void DisplayInstruction()
    {
        if (PromptService is null)
        {
            throw new InvalidOperationException();
        }

        Console.CursorTop = 12;

        foreach (var prompt in PromptService.Prompts)
        {
            Console.WriteLine(prompt.Instruction);
        }
    }
}
