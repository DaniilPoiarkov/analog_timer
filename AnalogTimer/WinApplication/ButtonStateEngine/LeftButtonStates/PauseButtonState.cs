namespace WinApplication.ButtonStateEngine.LeftButtonStates;

internal class PauseButtonState : ButtonsStateBase
{
    public override event EventHandler<EventArgs>? PausePressed;

    public PauseButtonState(Button leftBtn, Button rightBrn)
        : base(leftBtn, rightBrn)
    {
    }

    public override void LeftBtnClick()
    {
        LeftBtn.Text = "Resume";
        RightBtn.Enabled = true;

        PausePressed?.Invoke(this, EventArgs.Empty);
    }
}
