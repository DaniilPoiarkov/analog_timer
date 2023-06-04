namespace WinApplication.ButtonStateEngine.LeftButtonStates;

internal class ResumeButtonState : ButtonsStateBase
{
    public override event EventHandler<EventArgs>? PausePressed;

    public override event EventHandler<EventArgs>? CancelPressed;

    public ResumeButtonState(Button leftBtn, Button rightBrn)
        : base(leftBtn, rightBrn)
    {
        LeftBtn.Text = "Pause";
        RightBtn.Enabled = false;
    }

    public override void LeftBtnClick()
    {
        PausePressed?.Invoke(this, EventArgs.Empty);
    }

    public override void RightBtnClick()
    {
        CancelPressed?.Invoke(this, EventArgs.Empty);
    }
}
