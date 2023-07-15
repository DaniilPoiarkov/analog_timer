namespace WinApplication.ButtonStateEngine;

internal abstract class ButtonsStateBase
{
    protected readonly Button LeftBtn;

    protected readonly Button RightBtn;

#pragma warning disable CS0067

    public virtual event EventHandler<EventArgs>? StartPressed;

    public virtual event EventHandler<EventArgs>? PausePressed;

    public virtual event EventHandler<EventArgs>? ResumePressed;

    public virtual event EventHandler<EventArgs>? CancelPressed;

    public virtual event EventHandler<EventArgs>? CutPressed;

#pragma warning restore CS0067

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
