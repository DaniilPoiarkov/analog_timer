using AnalogTimer.Contracts;
using AnalogTimer.Implementations;
using AnalogTimer.Prompts.Implementations;
using NLog;

namespace AnalogTimer;

internal class ConsoleApplication
{
    private readonly IPromptService _promptService;

    private readonly Logger _logger = LogManager.GetCurrentClassLogger();

    private const int _exceptionLine = 8;

    public ConsoleApplication()
    {
        var timer = new Implementations.AnalogTimer(new ConsoleDisplayService(new DefaultTemplate()));

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

    public async Task Run()
    {
        _promptService.DisplayPrompts();

        while (true)
        {
            try
            {
                await _promptService.Run();
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
