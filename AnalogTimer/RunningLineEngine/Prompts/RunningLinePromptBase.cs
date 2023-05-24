using ConsoleInterface.Prompts;
using RunningLineEngine.Contracts;

namespace RunningLineEngine.Prompts;

public abstract class RunningLinePromptBase : PromptBase<IRunningLine>
{
    protected override void ValidateInput(List<string> values)
    {
        if (!values.Any())
        {
            throw new ArgumentException("Invalid input");
        }

        var keyWord = values[0];

        if (keyWord.Equals("run") || keyWord.Equals("-r") && values.Count >= 2)
        {
            var value = string.Join(' ', values.Skip(1));// new List<string>() { values[0], string.Join(' ', values.Skip(1)) };
            values.Clear();
            values.Add(keyWord);
            values.Add(value);
        }

        base.ValidateInput(values);
    }
}
