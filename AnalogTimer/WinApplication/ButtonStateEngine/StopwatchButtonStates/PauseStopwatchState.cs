namespace WinApplication.ButtonStateEngine.StopwatchButtonStates;

internal class PauseStopwatchState : ButtonsStateBase
{
    public override event EventHandler<EventArgs>? ResumePressed;

    public override event EventHandler<EventArgs>? CancelPressed;

    public PauseStopwatchState(Button leftBtn, Button rightBrn)
        : base(leftBtn, rightBrn)
    {
        LeftBtn.Text = "Resume";
        RightBtn.Text = "Reset";
    }

    public override void LeftBtnClick()
    {
        ResumePressed?.Invoke(this, EventArgs.Empty);
    }

    public override void RightBtnClick()
    {
        CancelPressed?.Invoke(this, EventArgs.Empty);
    }
}
