
using AnalogTimer.Contracts;
using AnalogTimer.Implementations;
using AnalogTimer.Prompts.Implementations;

Console.WriteLine("Hello Analog timer!");

Console.Clear();

var timer = new AnalogTimer.Implementations.AnalogTimer();

var prompts = new List<IPrompt>()
{ 
    new StartPrompt() 
};

var promptService = new PromptService(prompts, timer);

while (true)
{
    await promptService.Run();
}

timer.AddSeconds(5);
timer.Start();

Console.ReadKey();

timer.AddSeconds(15);

if(!timer.IsRunning)
    timer.Start();

Console.ReadKey();
