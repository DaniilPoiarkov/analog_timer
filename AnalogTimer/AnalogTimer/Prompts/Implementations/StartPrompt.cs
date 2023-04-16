namespace AnalogTimer.Prompts.Implementations;

public class StartPrompt : PromptBase
{
    public override string Instruction => "Write \'start x\' where \'x\' is amount of seconds";

    public override string Name => "Start";

    public override async Task Proceed(string? input, AnalogTimer.Implementations.AnalogTimer timer)
    {
        if(string.IsNullOrEmpty(input))
            throw new ArgumentNullException(nameof(input));

        var values = SplitInput(input)
            .Select(v => v.ToLower())
            .ToList();

        ValidateInput(values);

        var seconds = int.Parse(values[1]);

        if (seconds < 0)
            throw new Exception("Seconds cannot be below 0");

        if (timer.IsRunning)
            throw new Exception("Timer is already running");

        await timer.ResetState();
        timer.AddSeconds(seconds);
        timer.Start();
    }
}
