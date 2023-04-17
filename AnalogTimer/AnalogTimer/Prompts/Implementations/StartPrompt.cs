using AnalogTimer.Contracts;
namespace AnalogTimer.Prompts.Implementations;

public class StartPrompt : PromptBase
{
    public override string Instruction => "Write \'start x\' where \'x\' is amount of seconds";

    public override string Name => "Start";

    public override Task Proceed(string? input, IAnalogTimer timer)
    {
        if(string.IsNullOrEmpty(input))
            throw new ArgumentNullException(nameof(input));

        var values = ParseAndValidateInput(input);

        var seconds = int.Parse(values[1]);

        if (seconds < 0)
            throw new ArgumentException("Seconds cannot be below 0");

        if (timer.IsRunning)
            throw new InvalidOperationException("Timer is already running");

        timer.ResetState();
        timer.AddSeconds(seconds);
        timer.Start();

        return Task.CompletedTask;
    }
}
