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
            outputLabel = new Label();
            StartBtn = new Button();
            ResetBtn = new Button();
            OpenConsoleBtn = new Button();
            ConsoleInput = new TextBox();
            millisecondsOutput = new Label();
            colorDialog1 = new ColorDialog();
            cutOutput = new TextBox();
            label5 = new Label();
            TabWindow = new TabControl();
            TimerTab = new TabPage();
            label10 = new Label();
            label6 = new Label();
            label11 = new Label();
            numericUpDown3 = new NumericUpDown();
            numericUpDown1 = new NumericUpDown();
            button4 = new Button();
            textBox1 = new TextBox();
            button3 = new Button();
            button1 = new Button();
            button2 = new Button();
            numericUpDown2 = new NumericUpDown();
            label9 = new Label();
            label7 = new Label();
            numericUpDown4 = new NumericUpDown();
            label8 = new Label();
            StopwatchTab = new TabPage();
            button5 = new Button();
            button6 = new Button();
            TabWindow.SuspendLayout();
            TimerTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).BeginInit();
            StopwatchTab.SuspendLayout();
            SuspendLayout();
            // 
            // outputLabel
            // 
            outputLabel.AutoSize = true;
            outputLabel.BackColor = Color.FromArgb(33, 42, 62);
            outputLabel.Font = new Font("Segoe UI", 35F, FontStyle.Regular, GraphicsUnit.Point);
            outputLabel.ForeColor = Color.FromArgb(241, 246, 249);
            outputLabel.Location = new Point(-6, -2);
            outputLabel.Name = "outputLabel";
            outputLabel.Size = new Size(286, 88);
            outputLabel.TabIndex = 0;
            outputLabel.Text = "00:00:00:0";
            outputLabel.UseCompatibleTextRendering = true;
            // 
            // StartBtn
            // 
            StartBtn.BackColor = Color.FromArgb(57, 72, 103);
            StartBtn.FlatStyle = FlatStyle.Popup;
            StartBtn.ForeColor = Color.FromArgb(241, 246, 249);
            StartBtn.Location = new Point(6, 288);
            StartBtn.Margin = new Padding(3, 4, 3, 4);
            StartBtn.Name = "StartBtn";
            StartBtn.Size = new Size(150, 31);
            StartBtn.TabIndex = 1;
            StartBtn.Text = "Start";
            StartBtn.UseVisualStyleBackColor = false;
            StartBtn.Click += StartBtn_Click;
            // 
            // ResetBtn
            // 
            ResetBtn.BackColor = Color.FromArgb(57, 72, 103);
            ResetBtn.FlatStyle = FlatStyle.Popup;
            ResetBtn.ForeColor = Color.FromArgb(241, 246, 249);
            ResetBtn.Location = new Point(170, 288);
            ResetBtn.Margin = new Padding(3, 4, 3, 4);
            ResetBtn.Name = "ResetBtn";
            ResetBtn.Size = new Size(150, 31);
            ResetBtn.TabIndex = 5;
            ResetBtn.Text = "Reset";
            ResetBtn.UseVisualStyleBackColor = false;
            ResetBtn.Click += ResetBtn_Click;
            // 
            // OpenConsoleBtn
            // 
            OpenConsoleBtn.BackColor = Color.FromArgb(57, 72, 103);
            OpenConsoleBtn.FlatStyle = FlatStyle.Popup;
            OpenConsoleBtn.ForeColor = Color.FromArgb(241, 246, 249);
            OpenConsoleBtn.Location = new Point(6, 327);
            OpenConsoleBtn.Margin = new Padding(3, 4, 3, 4);
            OpenConsoleBtn.Name = "OpenConsoleBtn";
            OpenConsoleBtn.Size = new Size(315, 31);
            OpenConsoleBtn.TabIndex = 13;
            OpenConsoleBtn.Text = "Enable console";
            OpenConsoleBtn.UseVisualStyleBackColor = false;
            OpenConsoleBtn.Click += OpenConsoleBtn_Click;
            // 
            // ConsoleInput
            // 
            ConsoleInput.BackColor = Color.FromArgb(57, 72, 103);
            ConsoleInput.BorderStyle = BorderStyle.None;
            ConsoleInput.Enabled = false;
            ConsoleInput.ForeColor = Color.FromArgb(241, 246, 249);
            ConsoleInput.Location = new Point(6, 365);
            ConsoleInput.Name = "ConsoleInput";
            ConsoleInput.PlaceholderText = "Console mode";
            ConsoleInput.Size = new Size(315, 20);
            ConsoleInput.TabIndex = 14;
            ConsoleInput.KeyDown += ConsoleInputEnterKeydown;
            // 
            // millisecondsOutput
            // 
            millisecondsOutput.AutoSize = true;
            millisecondsOutput.BackColor = Color.FromArgb(33, 42, 62);
            millisecondsOutput.Font = new Font("Segoe UI", 35F, FontStyle.Regular, GraphicsUnit.Point);
            millisecondsOutput.ForeColor = Color.FromArgb(241, 246, 249);
            millisecondsOutput.Location = new Point(259, -2);
            millisecondsOutput.Name = "millisecondsOutput";
            millisecondsOutput.Size = new Size(52, 88);
            millisecondsOutput.TabIndex = 17;
            millisecondsOutput.Text = "0";
            millisecondsOutput.UseCompatibleTextRendering = true;
            // 
            // cutOutput
            // 
            cutOutput.Location = new Point(5, 120);
            cutOutput.Margin = new Padding(3, 4, 3, 4);
            cutOutput.Multiline = true;
            cutOutput.Name = "cutOutput";
            cutOutput.ReadOnly = true;
            cutOutput.ScrollBars = ScrollBars.Vertical;
            cutOutput.Size = new Size(315, 160);
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
            TabWindow.Size = new Size(351, 475);
            TabWindow.TabIndex = 22;
            // 
            // TimerTab
            // 
            TimerTab.BackColor = Color.FromArgb(33, 42, 62);
            TimerTab.BorderStyle = BorderStyle.Fixed3D;
            TimerTab.Controls.Add(button6);
            TimerTab.Controls.Add(button5);
            TimerTab.Controls.Add(label10);
            TimerTab.Controls.Add(label6);
            TimerTab.Controls.Add(label11);
            TimerTab.Controls.Add(numericUpDown3);
            TimerTab.Controls.Add(numericUpDown1);
            TimerTab.Controls.Add(button4);
            TimerTab.Controls.Add(textBox1);
            TimerTab.Controls.Add(button3);
            TimerTab.Controls.Add(button1);
            TimerTab.Controls.Add(button2);
            TimerTab.Controls.Add(numericUpDown2);
            TimerTab.Controls.Add(label9);
            TimerTab.Controls.Add(label7);
            TimerTab.Controls.Add(numericUpDown4);
            TimerTab.Controls.Add(label8);
            TimerTab.Location = new Point(4, 29);
            TimerTab.Name = "TimerTab";
            TimerTab.Padding = new Padding(3);
            TimerTab.Size = new Size(343, 442);
            TimerTab.TabIndex = 0;
            TimerTab.Text = "Timer";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.FromArgb(33, 42, 62);
            label10.Font = new Font("Segoe UI", 35F, FontStyle.Regular, GraphicsUnit.Point);
            label10.ForeColor = Color.FromArgb(241, 246, 249);
            label10.Location = new Point(258, -2);
            label10.Name = "label10";
            label10.Size = new Size(52, 88);
            label10.TabIndex = 24;
            label10.Text = "0";
            label10.UseCompatibleTextRendering = true;
            label10.Click += label10_Click;
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
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.FromArgb(33, 42, 62);
            label11.Font = new Font("Segoe UI", 35F, FontStyle.Regular, GraphicsUnit.Point);
            label11.ForeColor = Color.FromArgb(241, 246, 249);
            label11.Location = new Point(-6, -2);
            label11.Name = "label11";
            label11.Size = new Size(286, 88);
            label11.TabIndex = 23;
            label11.Text = "00:00:00:0";
            label11.UseCompatibleTextRendering = true;
            // 
            // numericUpDown3
            // 
            numericUpDown3.BackColor = Color.FromArgb(57, 72, 103);
            numericUpDown3.BorderStyle = BorderStyle.None;
            numericUpDown3.ForeColor = Color.FromArgb(241, 246, 249);
            numericUpDown3.Location = new Point(71, 257);
            numericUpDown3.Margin = new Padding(3, 4, 3, 4);
            numericUpDown3.Maximum = new decimal(new int[] { 59, 0, 0, 0 });
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(51, 23);
            numericUpDown3.TabIndex = 29;
            // 
            // numericUpDown1
            // 
            numericUpDown1.BackColor = Color.FromArgb(57, 72, 103);
            numericUpDown1.BorderStyle = BorderStyle.None;
            numericUpDown1.ForeColor = Color.FromArgb(241, 246, 249);
            numericUpDown1.Location = new Point(235, 257);
            numericUpDown1.Margin = new Padding(3, 4, 3, 4);
            numericUpDown1.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(51, 23);
            numericUpDown1.TabIndex = 34;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(57, 72, 103);
            button4.FlatStyle = FlatStyle.Popup;
            button4.ForeColor = Color.FromArgb(241, 246, 249);
            button4.Location = new Point(6, 288);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(86, 31);
            button4.TabIndex = 23;
            button4.Text = "Start";
            button4.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(57, 72, 103);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Enabled = false;
            textBox1.ForeColor = Color.FromArgb(241, 246, 249);
            textBox1.Location = new Point(6, 365);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Console mode";
            textBox1.Size = new Size(315, 20);
            textBox1.TabIndex = 33;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(57, 72, 103);
            button3.Enabled = false;
            button3.FlatStyle = FlatStyle.Popup;
            button3.ForeColor = Color.FromArgb(241, 246, 249);
            button3.Location = new Point(118, 288);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(86, 31);
            button3.TabIndex = 24;
            button3.Text = "Pause";
            button3.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(57, 72, 103);
            button1.FlatStyle = FlatStyle.Popup;
            button1.ForeColor = Color.FromArgb(241, 246, 249);
            button1.Location = new Point(6, 327);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(315, 31);
            button1.TabIndex = 32;
            button1.Text = "Enable console";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(57, 72, 103);
            button2.FlatStyle = FlatStyle.Popup;
            button2.ForeColor = Color.FromArgb(241, 246, 249);
            button2.Location = new Point(235, 288);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(86, 31);
            button2.TabIndex = 25;
            button2.Text = "Reset";
            button2.UseVisualStyleBackColor = false;
            // 
            // numericUpDown2
            // 
            numericUpDown2.BackColor = Color.FromArgb(57, 72, 103);
            numericUpDown2.BorderStyle = BorderStyle.None;
            numericUpDown2.ForeColor = Color.FromArgb(241, 246, 249);
            numericUpDown2.Location = new Point(129, 257);
            numericUpDown2.Margin = new Padding(3, 4, 3, 4);
            numericUpDown2.Maximum = new decimal(new int[] { 59, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(51, 23);
            numericUpDown2.TabIndex = 31;
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
            label7.Location = new Point(118, 233);
            label7.Name = "label7";
            label7.Size = new Size(64, 20);
            label7.TabIndex = 30;
            label7.Text = "Seconds";
            // 
            // numericUpDown4
            // 
            numericUpDown4.BackColor = Color.FromArgb(57, 72, 103);
            numericUpDown4.BorderStyle = BorderStyle.None;
            numericUpDown4.ForeColor = Color.FromArgb(241, 246, 249);
            numericUpDown4.Location = new Point(10, 257);
            numericUpDown4.Margin = new Padding(3, 4, 3, 4);
            numericUpDown4.Maximum = new decimal(new int[] { 24, 0, 0, 0 });
            numericUpDown4.Name = "numericUpDown4";
            numericUpDown4.Size = new Size(51, 23);
            numericUpDown4.TabIndex = 27;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.FromArgb(33, 42, 62);
            label8.ForeColor = Color.FromArgb(241, 246, 249);
            label8.Location = new Point(61, 233);
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
            StopwatchTab.Controls.Add(millisecondsOutput);
            StopwatchTab.Controls.Add(label5);
            StopwatchTab.Controls.Add(ConsoleInput);
            StopwatchTab.Controls.Add(outputLabel);
            StopwatchTab.Controls.Add(OpenConsoleBtn);
            StopwatchTab.Controls.Add(ResetBtn);
            StopwatchTab.Controls.Add(StartBtn);
            StopwatchTab.Location = new Point(4, 29);
            StopwatchTab.Name = "StopwatchTab";
            StopwatchTab.Padding = new Padding(3);
            StopwatchTab.Size = new Size(343, 442);
            StopwatchTab.TabIndex = 1;
            StopwatchTab.Text = "Stopwatch";
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(57, 72, 103);
            button5.FlatStyle = FlatStyle.Popup;
            button5.ForeColor = Color.FromArgb(241, 246, 249);
            button5.Location = new Point(6, 173);
            button5.Margin = new Padding(3, 4, 3, 4);
            button5.Name = "button5";
            button5.Size = new Size(116, 31);
            button5.TabIndex = 36;
            button5.Text = "Start 5 min";
            button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(57, 72, 103);
            button6.FlatStyle = FlatStyle.Popup;
            button6.ForeColor = Color.FromArgb(241, 246, 249);
            button6.Location = new Point(205, 173);
            button6.Margin = new Padding(3, 4, 3, 4);
            button6.Name = "button6";
            button6.Size = new Size(116, 31);
            button6.TabIndex = 37;
            button6.Text = "Start 10 min";
            button6.UseVisualStyleBackColor = false;
            // 
            // AnalogTimerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(33, 42, 62);
            ClientSize = new Size(377, 499);
            Controls.Add(TabWindow);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "AnalogTimerForm";
            Text = "Not so Analog Timer";
            TabWindow.ResumeLayout(false);
            TimerTab.ResumeLayout(false);
            TimerTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).EndInit();
            StopwatchTab.ResumeLayout(false);
            StopwatchTab.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label outputLabel;
        private Button StartBtn;
        private Button ResetBtn;
        private Button OpenConsoleBtn;
        private TextBox ConsoleInput;
        private Label millisecondsOutput;
        private ColorDialog colorDialog1;
        private TextBox cutOutput;
        private Label label5;
        private TabControl TabWindow;
        private TabPage TimerTab;
        private TabPage StopwatchTab;
        private Label label10;
        private Label label6;
        private Label label11;
        private NumericUpDown numericUpDown3;
        private NumericUpDown numericUpDown1;
        private Button button4;
        private TextBox textBox1;
        private Button button3;
        private Button button1;
        private Button button2;
        private NumericUpDown numericUpDown2;
        private Label label9;
        private Label label7;
        private NumericUpDown numericUpDown4;
        private Label label8;
        private Button button6;
        private Button button5;
    }
}