using AnalogTimer.DigitDrawers.Implementations;
using AnalogTimer.Implementations;
using AnalogTimer.Prompts.Implementations;

/*
var nine = new NineDrawer();
var eight = new EightDrawer();
var seven = new SevenDrawer();
var six = new SixDrawer();
var five = new FiveDrawer();
var four = new FourDrawer();
var three = new ThreeDrawer();
var two = new TwoDrawer();
var one = new OneDrawer();
var zero = new ZeroDrawer();

var template = new DefaultTemplate();

zero.Draw(0, template);
await Task.Delay(1000);
nine.Draw(0, template);
await Task.Delay(1000);
eight.Draw(0, template);
await Task.Delay(1000);
seven.Draw(0, template);
await Task.Delay(1000);
six.Draw(0, template);
await Task.Delay(1000);
five.Draw(0, template);
await Task.Delay(1000);
four.Draw(0, template);
await Task.Delay(1000);
three.Draw(0, template);
await Task.Delay(1000);
two.Draw(0, template);
await Task.Delay(1000);
one.Draw(0, template);
await Task.Delay(1000);
zero.Draw(0, template);

return;
*/

var timer = new AnalogTimer.Implementations.AnalogTimer();

var promptService = new PromptServiceBuilder(timer)
    .Add<StartPrompt>()
    .Add<PausePrompt>()
    .Add<ResetPrompt>()
    .Add<AddSecondsPrompt>()
    .Add<AddMinutesPrompt>()
    .Add<AddHoursPrompt>()
    .Add<ChangeSpeedPrompt>()
    .Add<CloseTimerPrompt>()
    .Build();

promptService.DisplayPrompts();

while (true)
{
    await promptService.Run();
}
