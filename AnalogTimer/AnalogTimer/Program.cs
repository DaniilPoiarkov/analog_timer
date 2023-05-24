using AnalogTimer;

static int LengthOfLastWord(string s)
{
    var sum = 0;
    var wasEmpty = false;

    foreach (var ch in s)
    {
        if (ch == ' ')
        {
            wasEmpty = true;
            continue;
        }

        if (wasEmpty)
        {
            wasEmpty = false;
            sum = 0;
        }

        sum++;
    }

    return sum;
}

var x = LengthOfLastWord("Fly  me   to the moon   ");

var app = new ConsoleApplication();

await app.Run();
