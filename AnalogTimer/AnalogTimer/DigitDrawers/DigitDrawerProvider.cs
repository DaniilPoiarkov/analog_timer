using AnalogTimer.Contracts;
using AnalogTimer.DigitDrawers.Implementations;

namespace AnalogTimer.DigitDrawers;

public class DigitDrawerProvider
{
    public static IDigitDrawer GetDrawer(int digit)
    {
        return digit switch
        {
            0 => new ZeroDrawer(),
            1 => new OneDrawer(),
            2 => new TwoDrawer(),
            3 => new ThreeDrawer(),
            4 => new FourDrawer(),
            5 => new FiveDrawer(),
            6 => new SixDrawer(),
            7 => new SevenDrawer(),
            8 => new EightDrawer(),
            9 => new NineDrawer(),
            _ => throw new ArgumentException("Not a digit", nameof(digit))
        };
    }
}
