namespace WinApplication.ButtonStateEngine.LeftButtonStates;

internal class ResumeButtonState : ButtonsStateBase
{
    public override event EventHandler<EventArgs>? ResumePressed;

    public override event EventHandler<EventArgs>? CancelPressed;

    public ResumeButtonState(Button leftBtn, Button rightBrn)
        : base(leftBtn, rightBrn)
    {
    }

    public override void LeftBtnClick()
    {
        LeftBtn.Text = "Pause";
        RightBtn.Enabled = false;

        ResumePressed?.Invoke(this, EventArgs.Empty);
    }

    public override void RightBtnClick()
    {
        LeftBtn.Text = "Start";
        RightBtn.Enabled = false;
        CancelPressed?.Invoke(this, EventArgs.Empty);
    }
}
