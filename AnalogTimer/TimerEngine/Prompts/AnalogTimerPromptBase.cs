using AnalogTimer.Contracts;
using ConsoleInterface.InputFlyweight;
using ConsoleInterface.Prompts;

namespace AnalogTimer.Prompts;

public abstract class AnalogTimerPromptBase : PromptBase, IAnalogTimerPrompt
{
    public abstract Task Proceed(string input, IAnalogTimer timer);

    protected static void ValidateFlags(IEnumerable<(string Flag, string Value)> flags, IEnumerable<IAnalogTimerShortcutFlag> shortcuts)
    {
        if (!flags.All(f => shortcuts.Any(s => s.Shortcut.Equals(f.Flag))))
        {
            var unexpected = flags.Where(f =>
                !shortcuts.Any(s => s.Shortcut.Equals(f.Flag)))
                .Select(f => $"-{f.Flag}");

            throw new InvalidOperationException($"Unexpected flag(s) {string.Join(", ", unexpected)}");
        }
    }

    protected static IEnumerable<(string Flag, string Value)> GenerateFlags(UserInput userInput, IEnumerable<IAnalogTimerShortcutFlag> shortcuts)
    {
        var flags = ParseUserInput(userInput);
        ValidateFlags(flags, shortcuts);
        return flags;
    }
}
