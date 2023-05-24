using AnalogTimer.Contracts;
using AnalogTimer.Models.Enums;
using AnalogTimer.Prompts;

namespace TimerEngine.Prompts.Implementations;

public class ChangeTimerTypePrompt : PromptBase
{
    public override string Name => "type";

    public override string Instruction => "Write \'type x\' or \'-t x\' where x is one of \'timer\' or \'stopwatch\' to change mode.\n\t" +
        "Flags: \'-t\' and \'-s\' represents \'x\' value accordingly.";

    public override string Shortcut => "-t";

    public override Task Proceed(string input, IAnalogTimer timer)
    {
        var value = ParseAndValidateInput(input)[1];

        if (value.StartsWith('-'))
        {
            var type = value switch
            {
                "-s" => TimerType.Stopwatch,
                "-t" => TimerType.Timer,
                _ => throw new ArgumentException($"Unexpected flag \'{value}\'", nameof(input))
            };

            timer.SetTimerType(type);
            return Task.CompletedTask;
        }


        var providedValue = $"{char.ToUpper(value[0])}{value[1..].ToLower()}";

        var exists = Enum.GetNames<TimerType>()
            .Any(n => n.Equals(providedValue));

        if (!exists)
        {
            throw new ArgumentException($"Invalid type \'{value}\'", nameof(input));
        }

        var enumType = Enum.Parse<TimerType>(providedValue);
        timer.SetTimerType(enumType);

        return Task.CompletedTask;
    }
}
