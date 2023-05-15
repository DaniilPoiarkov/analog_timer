namespace WinApplication;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void StartBtn_Click(object sender, EventArgs e)
    {
        outputLabel.Text = $"{HoursInput.Value}:{MinutesInput.Value}:{SecondsInput.Value}";
    }

    private void PauseBtn_Click(object sender, EventArgs e)
    {

    }

    private void ResetBtn_Click(object sender, EventArgs e)
    {
        outputLabel.Text = string.Empty;
    }

    private void HoursInput_Click(object sender, EventArgs e)
    {
        
    }

    private void MinutesInput_Click(object sender, EventArgs e)
    {
        
    }

    private void SecondsInput_Click(object sender, EventArgs e)
    {
        
    }

    private void OpenConsoleBtn_Click(object sender, EventArgs e)
    {

    }
}
