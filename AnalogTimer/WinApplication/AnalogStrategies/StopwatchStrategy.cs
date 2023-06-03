using WinApplication.Contracts;

namespace WinApplication.AnalogStrategies;

internal class StopwatchStrategy : IAnalogStrategy
{
    private readonly AnalogTimerForm _timerForm;

    public StopwatchStrategy(AnalogTimerForm timerForm)
    {
        _timerForm = timerForm;
    }

    public void HandleStart()
    {
        
    }
}
