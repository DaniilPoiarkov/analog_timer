namespace WinApplication.ButtonStateEngine;

internal abstract class ButtonsStateBase
{
    protected readonly Button LeftBtn;

    protected readonly Button RightBtn;

    public virtual event EventHandler<EventArgs>? StartPressed;

    public virtual event EventHandler<EventArgs>? PausePressed;

    public virtual event EventHandler<EventArgs>? ResumePressed;

    public virtual event EventHandler<EventArgs>? CancelPressed;


    protected ButtonsStateBase(Button leftBtn, Button rightBrn)
    {
        LeftBtn = leftBtn;
        RightBtn = rightBrn;
    }

    public virtual void LeftBtnClick()
    {

    }

    public virtual void RightBtnClick()
    {

    }
}
