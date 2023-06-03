namespace WinApplication.Statics;

internal static class Extensions
{
    public delegate void SetMillisecondCallback(string text);

    internal static DialogResult DisplayError(string error)
    {
        return MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
