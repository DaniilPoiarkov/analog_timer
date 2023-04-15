using AnalogTimer.Contracts;

namespace AnalogTimer.Implementations;

public class DefaultPattern : ITimerTemplate
{
    public char Pattern => '█';
}
