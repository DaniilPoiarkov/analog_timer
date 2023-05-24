using ConsoleInterface.EntityContracts;

namespace ConsoleInterface.Prompts;

public class ChangeSpeedPrompt<TEntity> : PromptBase<TEntity>
    where TEntity : ISpeedChangable
{
    public override string Name => "speed";

    public override string Instruction => "Write \'speed x\' where \'x\' represents speed coefficient.";

    public override string Shortcut => Name;

    public override Task Proceed(string input, TEntity timer)
    {
        var values = ParseAndValidateInput(input);

        var ticksPerSecond = int.Parse(values[1]);

        timer.ChangeSpeed(ticksPerSecond);

        return Task.CompletedTask;
    }
}
