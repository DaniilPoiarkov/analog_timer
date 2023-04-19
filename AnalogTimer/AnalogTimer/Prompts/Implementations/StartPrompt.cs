using AnalogTimer.Contracts;
using AnalogTimer.InputFlyweight;
using AnalogTimer.Prompts.ShortcutFlags.StartPromptFlags;

namespace AnalogTimer.Prompts.Implementations;

public class StartPrompt : PromptBase
{
    public override string Instruction => "Write \'start\' to start timer.\n\t" +
        "Flags: \'-h\', \'-m\', \'-s\' allows you to add hours, minutes and seconds accordingly.\n\t\t" +
        "Usage with positive number which represents amount of specific value.";

    public override string Name => "start";

    private readonly List<IShortcutFlag> _shortcutFlags;

    public StartPrompt()
    {
        _shortcutFlags = new List<IShortcutFlag>()
        {
            new StartSecondsFlag(),
            new StartMinutesFlag(),
            new StartHoursFlag(),
        };
    }

    public override async Task Proceed(string input, IAnalogTimer timer)
    {
        var userInput = new UserInput(input);

        if (userInput.Tokens.Count() == 1)
        {
            timer.Start();
        }

        var parsed = userInput.Tokens
            .Where(t => t.Type == Models.Enums.TokenType.Flag)
            .Select(t => t.Value
                .Trim()
                .Split(' '));

        if (!parsed.Any())
        {
            throw new InvalidOperationException($"Cannot parse expression \'{input}\'. Ensure that you are using only valid shorcuts",
                new Exception($"Tokens: {string.Join(' ', userInput.Tokens.Select(t => t.Value))}{Environment.NewLine}" +
                    $"Parsed: {string.Join(',', parsed.Select(p => string.Join(' ', p)))}"));
        }

        if (parsed.Any(p => p.Length != 2))
        {
            var unexpected = parsed.Where(p => p.Length != 2)
                .Select(p => string.Join(" ", p))
                .Select(v => $"\'-{v}\'");

            throw new InvalidOperationException($"Unexpected value(s) {string.Join(' ', unexpected)}");
        }

        var flags = parsed.Where(v => v.Length == 2)
            .Select(v => (Flag: v[0], Value: v[1]))
            .ToList();

        if(!flags.All(f => _shortcutFlags.Any(s => s.Shortcut.Equals(f.Flag))))
        {
            var unexpected = flags.Where(f => 
                !_shortcutFlags.Any(s => s.Shortcut.Equals(f.Flag)))
                .Select(f => $"-{f.Flag}");

            throw new InvalidOperationException($"Unexpected flag(s) {string.Join(", ", unexpected)}");
        }

        timer.ResetState();

        var tasks = new List<Task>(flags.Count);

        flags.ForEach(f =>
        {
            var handler = _shortcutFlags.First(s => s.Shortcut.Equals(f.Flag));
            tasks.Add(handler.Handle(f.Value, timer));
        });

        await Task.WhenAll(tasks);

        timer.Start();
    }
}
