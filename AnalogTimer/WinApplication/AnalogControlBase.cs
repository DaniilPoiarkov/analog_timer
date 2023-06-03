using MyTimer = AnalogTimer.Implementations.AnalogTimer;
using static WinApplication.Statics.Extensions;

namespace WinApplication;

public partial class AnalogControlBase : UserControl
{
    protected readonly MyTimer Timer;
    public AnalogControlBase()
    {
        InitializeComponent();

        Timer = new MyTimer();
    }

    protected void UpdateTimerState(Action<MyTimer> action, Action? onSuccess = null)
    {
        try
        {
            action.Invoke(Timer);
            onSuccess?.Invoke();
        }
        catch (Exception ex)
        {
            DisplayError(ex.Message);
        }
    }

    protected async Task UpdateTimerState(Func<MyTimer, Task> action, Action? onSuccess = null)
    {
        try
        {
            await action.Invoke(Timer);
            onSuccess?.Invoke();
        }
        catch (Exception ex)
        {
            DisplayError(ex.Message);
        }
    }
}
