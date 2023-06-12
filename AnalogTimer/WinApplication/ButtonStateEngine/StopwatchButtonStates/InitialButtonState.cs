namespace WinApplication.ButtonStateEngine.StopwatchButtonStates;

internal class InitialButtonState : ButtonsStateBase
{
    public override event EventHandler<EventArgs>? StartPressed;

    public InitialButtonState(Button leftBtn, Button rightBrn)
        : base(leftBtn, rightBrn)
    {
        LeftBtn.Text = "Start";
        RightBtn.Enabled = false;
        RightBtn.Text = string.Empty;
    }

    public override void LeftBtnClick()
    {
        StartPressed?.Invoke(this, EventArgs.Empty);
    }
}
