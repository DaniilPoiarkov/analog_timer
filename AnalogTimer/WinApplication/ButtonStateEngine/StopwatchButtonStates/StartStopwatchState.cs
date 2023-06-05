namespace WinApplication.ButtonStateEngine.StopwatchButtonStates;

internal class StartStopwatchState : ButtonsStateBase
{
    public override event EventHandler<EventArgs>? CutPressed;

    public override event EventHandler<EventArgs>? PausePressed;

    public StartStopwatchState(Button leftBtn, Button rightBrn)
        : base(leftBtn, rightBrn)
    {
        LeftBtn.Text = "Pause";
        RightBtn.Text = "Cut";
        RightBtn.Enabled = true;
    }

    public override void LeftBtnClick()
    {
        PausePressed?.Invoke(this, EventArgs.Empty);
    }

    public override void RightBtnClick()
    {
        CutPressed?.Invoke(this, EventArgs.Empty);
    }
}
