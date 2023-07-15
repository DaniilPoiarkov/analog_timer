namespace WinApplication
{
    partial class AnalogTimerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnalogTimerForm));
            TabWindow = new TabControl();
            TimerTab = new TabPage();
            analogTimerControl1 = new AnalogTimerControl();
            StopwatchTab = new TabPage();
            newStopwatchControl1 = new NewStopwatchControl();
            TabWindow.SuspendLayout();
            TimerTab.SuspendLayout();
            StopwatchTab.SuspendLayout();
            SuspendLayout();
            // 
            // TabWindow
            // 
            TabWindow.Controls.Add(TimerTab);
            TabWindow.Controls.Add(StopwatchTab);
            TabWindow.Location = new Point(11, 12);
            TabWindow.Name = "TabWindow";
            TabWindow.SelectedIndex = 0;
            TabWindow.Size = new Size(353, 365);
            TabWindow.TabIndex = 22;
            // 
            // TimerTab
            // 
            TimerTab.BackColor = Color.FromArgb(33, 42, 62);
            TimerTab.BackgroundImageLayout = ImageLayout.Center;
            TimerTab.BorderStyle = BorderStyle.Fixed3D;
            TimerTab.Controls.Add(analogTimerControl1);
            TimerTab.Location = new Point(4, 29);
            TimerTab.Name = "TimerTab";
            TimerTab.Padding = new Padding(3);
            TimerTab.Size = new Size(345, 332);
            TimerTab.TabIndex = 0;
            TimerTab.Text = "Timer";
            // 
            // analogTimerControl1
            // 
            analogTimerControl1.BackColor = Color.FromArgb(33, 42, 62);
            analogTimerControl1.Location = new Point(-6, -3);
            analogTimerControl1.Name = "analogTimerControl1";
            analogTimerControl1.Size = new Size(353, 333);
            analogTimerControl1.TabIndex = 0;
            // 
            // StopwatchTab
            // 
            StopwatchTab.BackColor = Color.FromArgb(33, 42, 62);
            StopwatchTab.BorderStyle = BorderStyle.Fixed3D;
            StopwatchTab.Controls.Add(newStopwatchControl1);
            StopwatchTab.Location = new Point(4, 29);
            StopwatchTab.Name = "StopwatchTab";
            StopwatchTab.Padding = new Padding(3);
            StopwatchTab.Size = new Size(345, 332);
            StopwatchTab.TabIndex = 1;
            StopwatchTab.Text = "Stopwatch";
            // 
            // newStopwatchControl1
            // 
            newStopwatchControl1.BackColor = Color.FromArgb(33, 42, 62);
            newStopwatchControl1.Location = new Point(-6, -3);
            newStopwatchControl1.Name = "newStopwatchControl1";
            newStopwatchControl1.Size = new Size(353, 337);
            newStopwatchControl1.TabIndex = 0;
            // 
            // AnalogTimerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(33, 42, 62);
            ClientSize = new Size(377, 382);
            Controls.Add(TabWindow);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "AnalogTimerForm";
            Text = "Not so Analog Timer";
            TabWindow.ResumeLayout(false);
            TimerTab.ResumeLayout(false);
            StopwatchTab.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TabControl TabWindow;
        private TabPage TimerTab;
        private TabPage StopwatchTab;
        private AnalogTimerControl analogTimerControl1;
        private NewStopwatchControl newStopwatchControl1;
    }
}