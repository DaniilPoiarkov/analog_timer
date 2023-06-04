namespace WinApplication.ButtonStateEngine.LeftButtonStates;

internal class CancelButtonState : ButtonsStateBase
{
    public override event EventHandler<EventArgs>? CancelPressed;

    public CancelButtonState(Button leftBtn, Button rightBrn)
        : base(leftBtn, rightBrn)
    {
    }

    public override void RightBtnClick()
    {
        CancelPressed?.Invoke(this, EventArgs.Empty);
    }
}
