
Console.WriteLine("Hello Analog timer!");

Console.Clear();

var timer = new AnalogTimer.Implementations.AnalogTimer();

timer.AddSeconds(5);
timer.Start();

Console.ReadKey();

timer.AddSeconds(15);

if(!timer.IsRunning)
    timer.Start();

Console.ReadKey();
