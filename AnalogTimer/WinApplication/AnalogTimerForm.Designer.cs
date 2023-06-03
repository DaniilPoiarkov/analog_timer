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
            TimerStartTenMinBtn = new Button();
            TimerStartFiveMinBtn = new Button();
            TimerMsOutput = new Label();
            label6 = new Label();
            TimerOutput = new Label();
            MinutesInput = new NumericUpDown();
            TickPerSecondInput = new NumericUpDown();
            SwitchTimerBtn = new Button();
            TimerConsoleInput = new TextBox();
            TimerOpenConsoleBtn = new Button();
            TimerCaancelBtn = new Button();
            SecondsInput = new NumericUpDown();
            label9 = new Label();
            label7 = new Label();
            HoursInput = new NumericUpDown();
            label8 = new Label();
            StopwatchTab = new TabPage();
            TabWindow.SuspendLayout();
            TimerTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MinutesInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TickPerSecondInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SecondsInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)HoursInput).BeginInit();
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
            TabWindow.Selected += TabSelectClick;
            // 
            // TimerTab
            // 
            TimerTab.BackColor = Color.FromArgb(33, 42, 62);
            TimerTab.BackgroundImageLayout = ImageLayout.Center;
            TimerTab.BorderStyle = BorderStyle.Fixed3D;
            TimerTab.Controls.Add(TimerStartTenMinBtn);
            TimerTab.Controls.Add(TimerStartFiveMinBtn);
            TimerTab.Controls.Add(TimerMsOutput);
            TimerTab.Controls.Add(label6);
            TimerTab.Controls.Add(TimerOutput);
            TimerTab.Controls.Add(MinutesInput);
            TimerTab.Controls.Add(TickPerSecondInput);
            TimerTab.Controls.Add(SwitchTimerBtn);
            TimerTab.Controls.Add(TimerConsoleInput);
            TimerTab.Controls.Add(TimerOpenConsoleBtn);
            TimerTab.Controls.Add(TimerCaancelBtn);
            TimerTab.Controls.Add(SecondsInput);
            TimerTab.Controls.Add(label9);
            TimerTab.Controls.Add(label7);
            TimerTab.Controls.Add(HoursInput);
            TimerTab.Controls.Add(label8);
            TimerTab.Location = new Point(4, 29);
            TimerTab.Name = "TimerTab";
            TimerTab.Padding = new Padding(3);
            TimerTab.Size = new Size(345, 398);
            TimerTab.TabIndex = 0;
            TimerTab.Text = "Timer";
            // 
            // TimerStartTenMinBtn
            // 
            TimerStartTenMinBtn.BackColor = Color.FromArgb(57, 72, 103);
            TimerStartTenMinBtn.FlatStyle = FlatStyle.Popup;
            TimerStartTenMinBtn.ForeColor = Color.FromArgb(241, 246, 249);
            TimerStartTenMinBtn.Location = new Point(205, 173);
            TimerStartTenMinBtn.Margin = new Padding(3, 4, 3, 4);
            TimerStartTenMinBtn.Name = "TimerStartTenMinBtn";
            TimerStartTenMinBtn.Size = new Size(116, 31);
            TimerStartTenMinBtn.TabIndex = 37;
            TimerStartTenMinBtn.Text = "Start 10 min";
            TimerStartTenMinBtn.UseVisualStyleBackColor = false;
            // 
            // TimerStartFiveMinBtn
            // 
            TimerStartFiveMinBtn.BackColor = Color.FromArgb(57, 72, 103);
            TimerStartFiveMinBtn.FlatStyle = FlatStyle.Popup;
            TimerStartFiveMinBtn.ForeColor = Color.FromArgb(241, 246, 249);
            TimerStartFiveMinBtn.Location = new Point(6, 173);
            TimerStartFiveMinBtn.Margin = new Padding(3, 4, 3, 4);
            TimerStartFiveMinBtn.Name = "TimerStartFiveMinBtn";
            TimerStartFiveMinBtn.Size = new Size(116, 31);
            TimerStartFiveMinBtn.TabIndex = 36;
            TimerStartFiveMinBtn.Text = "Start 5 min";
            TimerStartFiveMinBtn.UseVisualStyleBackColor = false;
            // 
            // TimerMsOutput
            // 
            TimerMsOutput.AutoSize = true;
            TimerMsOutput.BackColor = Color.FromArgb(33, 42, 62);
            TimerMsOutput.Font = new Font("Segoe UI", 35F, FontStyle.Regular, GraphicsUnit.Point);
            TimerMsOutput.ForeColor = Color.FromArgb(241, 246, 249);
            TimerMsOutput.Location = new Point(258, -2);
            TimerMsOutput.Name = "TimerMsOutput";
            TimerMsOutput.Size = new Size(52, 88);
            TimerMsOutput.TabIndex = 24;
            TimerMsOutput.Text = "0";
            TimerMsOutput.UseCompatibleTextRendering = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.FromArgb(33, 42, 62);
            label6.ForeColor = Color.FromArgb(241, 246, 249);
            label6.Location = new Point(215, 233);
            label6.Name = "label6";
            label6.Size = new Size(118, 20);
            label6.TabIndex = 35;
            label6.Text = "Ticks per second";
            // 
            // TimerOutput
            // 
            TimerOutput.AutoSize = true;
            TimerOutput.BackColor = Color.FromArgb(33, 42, 62);
            TimerOutput.Font = new Font("Segoe UI", 35F, FontStyle.Regular, GraphicsUnit.Point);
            TimerOutput.ForeColor = Color.FromArgb(241, 246, 249);
            TimerOutput.Location = new Point(-6, -2);
            TimerOutput.Name = "TimerOutput";
            TimerOutput.Size = new Size(286, 88);
            TimerOutput.TabIndex = 23;
            TimerOutput.Text = "00:00:00:0";
            TimerOutput.UseCompatibleTextRendering = true;
            // 
            // MinutesInput
            // 
            MinutesInput.BackColor = Color.FromArgb(57, 72, 103);
            MinutesInput.BorderStyle = BorderStyle.None;
            MinutesInput.ForeColor = Color.FromArgb(241, 246, 249);
            MinutesInput.Location = new Point(89, 257);
            MinutesInput.Margin = new Padding(3, 4, 3, 4);
            MinutesInput.Maximum = new decimal(new int[] { 59, 0, 0, 0 });
            MinutesInput.Name = "MinutesInput";
            MinutesInput.Size = new Size(51, 23);
            MinutesInput.TabIndex = 29;
            // 
            // TickPerSecondInput
            // 
            TickPerSecondInput.BackColor = Color.FromArgb(57, 72, 103);
            TickPerSecondInput.BorderStyle = BorderStyle.None;
            TickPerSecondInput.ForeColor = Color.FromArgb(241, 246, 249);
            TickPerSecondInput.Location = new Point(245, 257);
            TickPerSecondInput.Margin = new Padding(3, 4, 3, 4);
            TickPerSecondInput.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            TickPerSecondInput.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            TickPerSecondInput.Name = "TickPerSecondInput";
            TickPerSecondInput.Size = new Size(51, 23);
            TickPerSecondInput.TabIndex = 34;
            TickPerSecondInput.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // SwitchTimerBtn
            // 
            SwitchTimerBtn.BackColor = Color.FromArgb(57, 72, 103);
            SwitchTimerBtn.FlatStyle = FlatStyle.Popup;
            SwitchTimerBtn.ForeColor = Color.FromArgb(241, 246, 249);
            SwitchTimerBtn.Location = new Point(6, 288);
            SwitchTimerBtn.Margin = new Padding(3, 4, 3, 4);
            SwitchTimerBtn.Name = "SwitchTimerBtn";
            SwitchTimerBtn.Size = new Size(160, 31);
            SwitchTimerBtn.TabIndex = 23;
            SwitchTimerBtn.Text = "Start";
            SwitchTimerBtn.UseVisualStyleBackColor = false;
            SwitchTimerBtn.Click += StartBtnClick;
            // 
            // TimerConsoleInput
            // 
            TimerConsoleInput.BackColor = Color.FromArgb(57, 72, 103);
            TimerConsoleInput.BorderStyle = BorderStyle.None;
            TimerConsoleInput.Enabled = false;
            TimerConsoleInput.ForeColor = Color.FromArgb(241, 246, 249);
            TimerConsoleInput.Location = new Point(6, 365);
            TimerConsoleInput.Name = "TimerConsoleInput";
            TimerConsoleInput.PlaceholderText = "Console mode";
            TimerConsoleInput.Size = new Size(325, 20);
            TimerConsoleInput.TabIndex = 33;
            // 
            // TimerOpenConsoleBtn
            // 
            TimerOpenConsoleBtn.BackColor = Color.FromArgb(57, 72, 103);
            TimerOpenConsoleBtn.FlatStyle = FlatStyle.Popup;
            TimerOpenConsoleBtn.ForeColor = Color.FromArgb(241, 246, 249);
            TimerOpenConsoleBtn.Location = new Point(6, 327);
            TimerOpenConsoleBtn.Margin = new Padding(3, 4, 3, 4);
            TimerOpenConsoleBtn.Name = "TimerOpenConsoleBtn";
            TimerOpenConsoleBtn.Size = new Size(325, 31);
            TimerOpenConsoleBtn.TabIndex = 32;
            TimerOpenConsoleBtn.Text = "Enable console";
            TimerOpenConsoleBtn.UseVisualStyleBackColor = false;
            // 
            // TimerCaancelBtn
            // 
            TimerCaancelBtn.BackColor = Color.FromArgb(57, 72, 103);
            TimerCaancelBtn.Enabled = false;
            TimerCaancelBtn.FlatStyle = FlatStyle.Popup;
            TimerCaancelBtn.ForeColor = Color.FromArgb(241, 246, 249);
            TimerCaancelBtn.Location = new Point(175, 288);
            TimerCaancelBtn.Margin = new Padding(3, 4, 3, 4);
            TimerCaancelBtn.Name = "TimerCaancelBtn";
            TimerCaancelBtn.Size = new Size(160, 31);
            TimerCaancelBtn.TabIndex = 25;
            TimerCaancelBtn.Text = "Reset";
            TimerCaancelBtn.UseVisualStyleBackColor = false;
            // 
            // SecondsInput
            // 
            SecondsInput.BackColor = Color.FromArgb(57, 72, 103);
            SecondsInput.BorderStyle = BorderStyle.None;
            SecondsInput.ForeColor = Color.FromArgb(241, 246, 249);
            SecondsInput.Location = new Point(164, 257);
            SecondsInput.Margin = new Padding(3, 4, 3, 4);
            SecondsInput.Maximum = new decimal(new int[] { 59, 0, 0, 0 });
            SecondsInput.Name = "SecondsInput";
            SecondsInput.Size = new Size(51, 23);
            SecondsInput.TabIndex = 31;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.FromArgb(33, 42, 62);
            label9.ForeColor = Color.FromArgb(241, 246, 249);
            label9.Location = new Point(13, 233);
            label9.Name = "label9";
            label9.Size = new Size(48, 20);
            label9.TabIndex = 26;
            label9.Text = "Hours";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.FromArgb(33, 42, 62);
            label7.ForeColor = Color.FromArgb(241, 246, 249);
            label7.Location = new Point(151, 233);
            label7.Name = "label7";
            label7.Size = new Size(64, 20);
            label7.TabIndex = 30;
            label7.Text = "Seconds";
            // 
            // HoursInput
            // 
            HoursInput.BackColor = Color.FromArgb(57, 72, 103);
            HoursInput.BorderStyle = BorderStyle.None;
            HoursInput.ForeColor = Color.FromArgb(241, 246, 249);
            HoursInput.Location = new Point(10, 257);
            HoursInput.Margin = new Padding(3, 4, 3, 4);
            HoursInput.Maximum = new decimal(new int[] { 24, 0, 0, 0 });
            HoursInput.Name = "HoursInput";
            HoursInput.Size = new Size(51, 23);
            HoursInput.TabIndex = 27;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.FromArgb(33, 42, 62);
            label8.ForeColor = Color.FromArgb(241, 246, 249);
            label8.Location = new Point(79, 233);
            label8.Name = "label8";
            label8.Size = new Size(61, 20);
            label8.TabIndex = 28;
            label8.Text = "Minutes";
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
            TimerTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)MinutesInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)TickPerSecondInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)SecondsInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)HoursInput).EndInit();
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
        private Label TimerMsOutput;
        private Label label6;
        private Label TimerOutput;
        private NumericUpDown MinutesInput;
        private NumericUpDown TickPerSecondInput;
        private Button SwitchTimerBtn;
        private TextBox TimerConsoleInput;
        private Button button3;
        private Button TimerOpenConsoleBtn;
        private Button TimerCaancelBtn;
        private NumericUpDown SecondsInput;
        private Label label9;
        private Label label7;
        private NumericUpDown HoursInput;
        private Label label8;
        private Button TimerStartTenMinBtn;
        private Button TimerStartFiveMinBtn;
    }
}