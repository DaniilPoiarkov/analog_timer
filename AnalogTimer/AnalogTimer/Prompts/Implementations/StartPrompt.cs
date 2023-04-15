namespace AnalogTimer.Prompts.Implementations;

public class StartPrompt : PromptBase
{
    public override string Instruction => "Write \'start x\' where x is amount of seconds";

    public override string Name => "Start";

    public override Task Proceed(string? input, AnalogTimer.Implementations.AnalogTimer timer)
    {
        if(string.IsNullOrEmpty(input))
            return Task.CompletedTask;

        var values = SplitInput(input).Select(v => v.ToLower()).ToList();

        if (!values.Any() || !values[0].Equals("start") || values.Count != 2)
        {
            return Task.CompletedTask;
        }

        var seconds = int.Parse(values[1]);

        if (seconds < 0)
            throw new Exception("Seconds cannot be below 0");

        if (timer.IsRunning)
            throw new Exception("Timer is already running");

        timer.AddSeconds(seconds);
        timer.Start();

        return Task.CompletedTask;
    }
}
