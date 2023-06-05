namespace WinApplication.ButtonStateEngine.TimerButtonStates;

internal class InitialButtonsState : ButtonsStateBase
{
    public override event EventHandler<EventArgs>? StartPressed;

    public InitialButtonsState(Button leftBtn, Button rightBrn)
        : base(leftBtn, rightBrn)
    {
        LeftBtn.Text = "Start";
        RightBtn.Enabled = false;
    }

    public override void LeftBtnClick()
    {
        StartPressed?.Invoke(this, EventArgs.Empty);
    }
}
