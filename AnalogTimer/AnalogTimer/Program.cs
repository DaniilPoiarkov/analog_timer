
Console.WriteLine("Hello Analog timer!");

var timer = new AnalogTimer.Implementations.AnalogTimer();

timer.AddSeconds(15);
timer.Start();

Console.ReadKey();
