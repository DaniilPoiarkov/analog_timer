using AnalogTimer.Contracts;

namespace AnalogTimer.Implementations;

public class DefaultTemplate : ITimerTemplate
{
    public char Pattern => '█';
}
