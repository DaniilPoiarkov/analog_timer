using AnalogTimer.Contracts;
using AnalogTimer.Helpers;
using AnalogTimer.Implementations;
using AnalogTimer.Prompts.Implementations;
using NLog;

namespace AnalogTimer;

internal class ConsoleApplication
{
    private readonly IPromptService _promptService;

    private readonly Logger _logger = LogManager.GetCurrentClassLogger();

    private const int _exceptionLine = 8;

    private const int _inputLine = 9;

    public ConsoleApplication()
    {
        var displayService = new ConsoleDisplayService(new DefaultTemplate());
        var timer = new Implementations.AnalogTimer();

        timer.Tick += displayService.DisplayTick;
        timer.Updated += displayService.DisplayUpdated;
        timer.TimerCut += displayService.DisplayCut;

        _promptService = new PromptServiceBuilder(timer)
            .Add<StartPrompt>()
            .Add<PausePrompt>()
            .Add<ResetPrompt>()
            .Add<AddSecondsPrompt>()
            .Add<AddMinutesPrompt>()
            .Add<AddHoursPrompt>()
            .Add<ChangeSpeedPrompt>()
            .Add<ChangeTimerTypePrompt>()
            .Add<CloseTimerPrompt>()
            .Add<CutTimerStatePrompt>()
            .Build();
    }

    public void DisplayPrompts()
    {
        Console.CursorTop = 12;

        foreach (var prompt in _promptService.Prompts)
        {
            Console.WriteLine(prompt.Instruction);
        }
    }

    private static string GetUserInput()
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

    public async Task Run()
    {
        DisplayPrompts();

        while (true)
        {
            try
            {
                string? input = GetUserInput();
                Console.CursorTop = _inputLine;
                Console.WriteLine(new string(' ', Console.BufferWidth));
                await _promptService.Consume(input);
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

    private void PrintException(string message, Exception? ex = null)
    {
        Console.CursorTop = _exceptionLine;
        Console.WriteLine(new string(' ', Console.WindowWidth));

        Console.CursorTop = _exceptionLine;
        Console.WriteLine($"Exception: {message}");
        _logger.Error(ex, message);
    }
}
