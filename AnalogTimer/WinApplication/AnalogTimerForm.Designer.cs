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
            StopwatchOutput = new Label();
            StopwatchStartBtn = new Button();
            StopwatchResetBtn = new Button();
            StopwatchOpenConsoleBtn = new Button();
            StopwatchConsoleInput = new TextBox();
            StopwatchMsOutput = new Label();
            colorDialog1 = new ColorDialog();
            cutOutput = new TextBox();
            label5 = new Label();
            TabWindow = new TabControl();
            TimerTab = new TabPage();
            analogTimerControl1 = new AnalogTimerControl();
            StopwatchTab = new TabPage();
            TabWindow.SuspendLayout();
            TimerTab.SuspendLayout();
            StopwatchTab.SuspendLayout();
            SuspendLayout();
            // 
            // StopwatchOutput
            // 
            StopwatchOutput.AutoSize = true;
            StopwatchOutput.BackColor = Color.FromArgb(33, 42, 62);
            StopwatchOutput.Font = new Font("Segoe UI", 35F, FontStyle.Regular, GraphicsUnit.Point);
            StopwatchOutput.ForeColor = Color.FromArgb(241, 246, 249);
            StopwatchOutput.Location = new Point(-6, -2);
            StopwatchOutput.Name = "StopwatchOutput";
            StopwatchOutput.Size = new Size(286, 88);
            StopwatchOutput.TabIndex = 0;
            StopwatchOutput.Text = "00:00:00:0";
            StopwatchOutput.UseCompatibleTextRendering = true;
            // 
            // StopwatchStartBtn
            // 
            StopwatchStartBtn.BackColor = Color.FromArgb(57, 72, 103);
            StopwatchStartBtn.FlatStyle = FlatStyle.Popup;
            StopwatchStartBtn.ForeColor = Color.FromArgb(241, 246, 249);
            StopwatchStartBtn.Location = new Point(6, 288);
            StopwatchStartBtn.Margin = new Padding(3, 4, 3, 4);
            StopwatchStartBtn.Name = "StopwatchStartBtn";
            StopwatchStartBtn.Size = new Size(160, 31);
            StopwatchStartBtn.TabIndex = 1;
            StopwatchStartBtn.Text = "Start";
            StopwatchStartBtn.UseVisualStyleBackColor = false;
            StopwatchStartBtn.Click += StartBtnClick;
            // 
            // StopwatchResetBtn
            // 
            StopwatchResetBtn.BackColor = Color.FromArgb(57, 72, 103);
            StopwatchResetBtn.FlatStyle = FlatStyle.Popup;
            StopwatchResetBtn.ForeColor = Color.FromArgb(241, 246, 249);
            StopwatchResetBtn.Location = new Point(175, 288);
            StopwatchResetBtn.Margin = new Padding(3, 4, 3, 4);
            StopwatchResetBtn.Name = "StopwatchResetBtn";
            StopwatchResetBtn.Size = new Size(160, 31);
            StopwatchResetBtn.TabIndex = 5;
            StopwatchResetBtn.Text = "Reset";
            StopwatchResetBtn.UseVisualStyleBackColor = false;
            StopwatchResetBtn.Click += ResetBtn_Click;
            // 
            // StopwatchOpenConsoleBtn
            // 
            StopwatchOpenConsoleBtn.BackColor = Color.FromArgb(57, 72, 103);
            StopwatchOpenConsoleBtn.FlatStyle = FlatStyle.Popup;
            StopwatchOpenConsoleBtn.ForeColor = Color.FromArgb(241, 246, 249);
            StopwatchOpenConsoleBtn.Location = new Point(6, 327);
            StopwatchOpenConsoleBtn.Margin = new Padding(3, 4, 3, 4);
            StopwatchOpenConsoleBtn.Name = "StopwatchOpenConsoleBtn";
            StopwatchOpenConsoleBtn.Size = new Size(325, 31);
            StopwatchOpenConsoleBtn.TabIndex = 13;
            StopwatchOpenConsoleBtn.Text = "Enable console";
            StopwatchOpenConsoleBtn.UseVisualStyleBackColor = false;
            StopwatchOpenConsoleBtn.Click += OpenConsoleBtn_Click;
            // 
            // StopwatchConsoleInput
            // 
            StopwatchConsoleInput.BackColor = Color.FromArgb(57, 72, 103);
            StopwatchConsoleInput.BorderStyle = BorderStyle.None;
            StopwatchConsoleInput.Enabled = false;
            StopwatchConsoleInput.ForeColor = Color.FromArgb(241, 246, 249);
            StopwatchConsoleInput.Location = new Point(6, 365);
            StopwatchConsoleInput.Name = "StopwatchConsoleInput";
            StopwatchConsoleInput.PlaceholderText = "Console mode";
            StopwatchConsoleInput.Size = new Size(325, 20);
            StopwatchConsoleInput.TabIndex = 14;
            StopwatchConsoleInput.KeyDown += ConsoleInputEnterKeydown;
            // 
            // StopwatchMsOutput
            // 
            StopwatchMsOutput.AutoSize = true;
            StopwatchMsOutput.BackColor = Color.FromArgb(33, 42, 62);
            StopwatchMsOutput.Font = new Font("Segoe UI", 35F, FontStyle.Regular, GraphicsUnit.Point);
            StopwatchMsOutput.ForeColor = Color.FromArgb(241, 246, 249);
            StopwatchMsOutput.Location = new Point(259, -2);
            StopwatchMsOutput.Name = "StopwatchMsOutput";
            StopwatchMsOutput.Size = new Size(52, 88);
            StopwatchMsOutput.TabIndex = 17;
            StopwatchMsOutput.Text = "0";
            StopwatchMsOutput.UseCompatibleTextRendering = true;
            // 
            // cutOutput
            // 
            cutOutput.Location = new Point(5, 120);
            cutOutput.Margin = new Padding(3, 4, 3, 4);
            cutOutput.Multiline = true;
            cutOutput.Name = "cutOutput";
            cutOutput.ReadOnly = true;
            cutOutput.ScrollBars = ScrollBars.Vertical;
            cutOutput.Size = new Size(326, 160);
            cutOutput.TabIndex = 18;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(33, 42, 62);
            label5.ForeColor = Color.FromArgb(241, 246, 249);
            label5.Location = new Point(6, 96);
            label5.Name = "label5";
            label5.Size = new Size(47, 20);
            label5.TabIndex = 21;
            label5.Text = "Leaps";
            // 
            // TabWindow
            // 
            TabWindow.Controls.Add(TimerTab);
            TabWindow.Controls.Add(StopwatchTab);
            TabWindow.Location = new Point(12, 12);
            TabWindow.Name = "TabWindow";
            TabWindow.SelectedIndex = 0;
            TabWindow.Size = new Size(353, 431);
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
            TimerTab.Size = new Size(345, 398);
            TimerTab.TabIndex = 0;
            TimerTab.Text = "Timer";
            // 
            // analogTimerControl1
            // 
            analogTimerControl1.BackColor = Color.FromArgb(33, 42, 62);
            analogTimerControl1.Location = new Point(-6, -2);
            analogTimerControl1.Name = "analogTimerControl1";
            analogTimerControl1.Size = new Size(353, 417);
            analogTimerControl1.TabIndex = 0;
            // 
            // StopwatchTab
            // 
            StopwatchTab.BackColor = Color.FromArgb(33, 42, 62);
            StopwatchTab.BorderStyle = BorderStyle.Fixed3D;
            StopwatchTab.Controls.Add(cutOutput);
            StopwatchTab.Controls.Add(StopwatchMsOutput);
            StopwatchTab.Controls.Add(label5);
            StopwatchTab.Controls.Add(StopwatchConsoleInput);
            StopwatchTab.Controls.Add(StopwatchOutput);
            StopwatchTab.Controls.Add(StopwatchOpenConsoleBtn);
            StopwatchTab.Controls.Add(StopwatchResetBtn);
            StopwatchTab.Controls.Add(StopwatchStartBtn);
            StopwatchTab.Location = new Point(4, 29);
            StopwatchTab.Name = "StopwatchTab";
            StopwatchTab.Padding = new Padding(3);
            StopwatchTab.Size = new Size(345, 398);
            StopwatchTab.TabIndex = 1;
            StopwatchTab.Text = "Stopwatch";
            // 
            // AnalogTimerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(33, 42, 62);
            ClientSize = new Size(377, 452);
            Controls.Add(TabWindow);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "AnalogTimerForm";
            Text = "Not so Analog Timer";
            TabWindow.ResumeLayout(false);
            TimerTab.ResumeLayout(false);
            StopwatchTab.ResumeLayout(false);
            StopwatchTab.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label StopwatchOutput;
        private Button StopwatchStartBtn;
        private Button StopwatchResetBtn;
        private Button StopwatchOpenConsoleBtn;
        private TextBox StopwatchConsoleInput;
        private Label StopwatchMsOutput;
        private ColorDialog colorDialog1;
        private TextBox cutOutput;
        private Label label5;
        private TabControl TabWindow;
        private TabPage TimerTab;
        private TabPage StopwatchTab;
        private Button button3;
        private AnalogTimerControl analogTimerControl1;
    }
}