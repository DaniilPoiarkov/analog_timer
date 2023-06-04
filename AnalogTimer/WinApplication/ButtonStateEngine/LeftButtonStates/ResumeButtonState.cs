namespace WinApplication.ButtonStateEngine.LeftButtonStates;

internal class ResumeButtonState : ButtonsStateBase
{
    public override event EventHandler<EventArgs>? ResumePressed;

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
}
