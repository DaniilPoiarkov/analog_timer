using AnalogTimer.Implementations;

Console.WriteLine("Hello Analog timer!");

Console.Clear();

var timer = new AnalogTimer.Implementations.AnalogTimer();

timer.AddSeconds(15);
timer.Start();

Console.ReadKey();

timer.AddSeconds(15);
Console.ReadKey();
