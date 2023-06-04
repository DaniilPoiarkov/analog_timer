namespace WinApplication.ButtonStateEngine.TimerButtonStates;

internal class StartButtonState : ButtonsStateBase
{
    public override event EventHandler<EventArgs>? PausePressed;

    public StartButtonState(Button leftBtn, Button rightBrn)
        : base(leftBtn, rightBrn)
    {
        LeftBtn.Text = "Pause";
        RightBtn.Enabled = false;
    }

    public override void LeftBtnClick()
    {
        PausePressed?.Invoke(this, EventArgs.Empty);
    }
}
