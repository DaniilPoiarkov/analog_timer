
Console.WriteLine("Hello Analog timer!");

var ts = TimeSpan.Zero;

var fiveSeconds = ts.Add(TimeSpan.FromSeconds(5));

while(fiveSeconds > TimeSpan.Zero)
{
    await Task.Delay(1000);

    fiveSeconds = fiveSeconds.Add(new TimeSpan(0, 0, -1));
    Console.WriteLine(fiveSeconds);
}
