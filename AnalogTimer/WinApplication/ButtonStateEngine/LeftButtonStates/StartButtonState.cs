namespace WinApplication.ButtonStateEngine.LeftButtonStates;

internal class StartButtonState : ButtonsStateBase
{
    public override event EventHandler<EventArgs>? StartPressed;

    public StartButtonState(Button leftBtn, Button rightBrn)
        : base(leftBtn, rightBrn)
    {
    }

    public override void LeftBtnClick()
    {
        LeftBtn.Text = "Pause";
        RightBtn.Enabled = false;

        StartPressed?.Invoke(this, EventArgs.Empty);
    }
}
