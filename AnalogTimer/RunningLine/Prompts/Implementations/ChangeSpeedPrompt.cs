using ConsoleApplicationBuilder.Prompts;
using RunningLineEngine.Contracts;

namespace RunningLine.Prompts.Implementations;

public class ChangeSpeedPrompt : PromptBase<IRunningLine>
{
    public override string Name => "speed";

    public override string Instruction => "Write \'speed x\' where \'x\' represents speed coefficient.";

    public override string Shortcut => Name;

    public override Task Proceed(string input, IRunningLine runningLine)
    {
        var values = ParseAndValidateInput(input);

        try
        {
            var ticksPerSecond = int.Parse(values[1]);
            runningLine.ChangeSpeed(ticksPerSecond);
        }
        catch (Exception ex)
            when (ex is FormatException || ex is ArgumentNullException)
        {
            throw new Exception($"\'{values[1]}\' is not correct value for speed. Use only integers, also fractions are not allowed.", ex);
        }
        catch(Exception ex)
            when (ex is OverflowException)
        {
            throw new Exception($"Maximum value for speed is {int.MaxValue}", ex);
        }

        return Task.CompletedTask;
    }
}
