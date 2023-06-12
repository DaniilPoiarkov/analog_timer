namespace WinApplication.ButtonStateEngine.TimerButtonStates;

internal class PauseButtonState : ButtonsStateBase
{
    public override event EventHandler<EventArgs>? ResumePressed;

    public override event EventHandler<EventArgs>? CancelPressed;

    public PauseButtonState(Button leftBtn, Button rightBrn)
        : base(leftBtn, rightBrn)
    {
        LeftBtn.Text = "Resume";
        RightBtn.Enabled = true;
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
