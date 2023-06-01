﻿namespace WinApplication
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
            PauseBtn = new Button();
            TimerTypeComboBox = new ComboBox();
            ResetBtn = new Button();
            label2 = new Label();
            HoursInput = new NumericUpDown();
            MinutesInput = new NumericUpDown();
            label1 = new Label();
            SecondsInput = new NumericUpDown();
            label3 = new Label();
            OpenConsoleBtn = new Button();
            ConsoleInput = new TextBox();
            ChangeSpeedInput = new NumericUpDown();
            label4 = new Label();
            millisecondsOutput = new Label();
            colorDialog1 = new ColorDialog();
            cutOutput = new TextBox();
            cutBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)HoursInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MinutesInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SecondsInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ChangeSpeedInput).BeginInit();
            SuspendLayout();
            // 
            // outputLabel
            // 
            outputLabel.AutoSize = true;
            outputLabel.BackColor = Color.FromArgb(33, 42, 62);
            outputLabel.Font = new Font("Segoe UI", 45F, FontStyle.Regular, GraphicsUnit.Point);
            outputLabel.ForeColor = Color.FromArgb(241, 246, 249);
            outputLabel.Location = new Point(11, 83);
            outputLabel.Name = "outputLabel";
            outputLabel.Size = new Size(367, 113);
            outputLabel.TabIndex = 0;
            outputLabel.Text = "00:00:00:0";
            outputLabel.UseCompatibleTextRendering = true;
            // 
            // StartBtn
            // 
            StartBtn.BackColor = Color.FromArgb(57, 72, 103);
            StartBtn.FlatStyle = FlatStyle.Popup;
            StartBtn.ForeColor = Color.FromArgb(241, 246, 249);
            StartBtn.Location = new Point(13, 360);
            StartBtn.Margin = new Padding(3, 4, 3, 4);
            StartBtn.Name = "StartBtn";
            StartBtn.Size = new Size(86, 31);
            StartBtn.TabIndex = 1;
            StartBtn.Text = "Start";
            StartBtn.UseVisualStyleBackColor = false;
            StartBtn.Click += StartBtn_Click;
            // 
            // PauseBtn
            // 
            PauseBtn.BackColor = Color.FromArgb(57, 72, 103);
            PauseBtn.Enabled = false;
            PauseBtn.FlatStyle = FlatStyle.Popup;
            PauseBtn.ForeColor = Color.FromArgb(241, 246, 249);
            PauseBtn.Location = new Point(123, 360);
            PauseBtn.Margin = new Padding(3, 4, 3, 4);
            PauseBtn.Name = "PauseBtn";
            PauseBtn.Size = new Size(86, 31);
            PauseBtn.TabIndex = 2;
            PauseBtn.Text = "Pause";
            PauseBtn.UseVisualStyleBackColor = false;
            PauseBtn.Click += PauseBtn_Click;
            // 
            // TimerTypeComboBox
            // 
            TimerTypeComboBox.BackColor = Color.FromArgb(57, 72, 103);
            TimerTypeComboBox.DisplayMember = "Stopwatch";
            TimerTypeComboBox.FlatStyle = FlatStyle.Popup;
            TimerTypeComboBox.ForeColor = Color.FromArgb(241, 246, 249);
            TimerTypeComboBox.FormattingEnabled = true;
            TimerTypeComboBox.Items.AddRange(new object[] { "Timer", "Stopwatch" });
            TimerTypeComboBox.Location = new Point(14, 220);
            TimerTypeComboBox.Margin = new Padding(3, 4, 3, 4);
            TimerTypeComboBox.Name = "TimerTypeComboBox";
            TimerTypeComboBox.Size = new Size(173, 28);
            TimerTypeComboBox.TabIndex = 4;
            TimerTypeComboBox.Text = "Stopwatch";
            TimerTypeComboBox.SelectedValueChanged += TimerTypeChanged;
            // 
            // ResetBtn
            // 
            ResetBtn.BackColor = Color.FromArgb(57, 72, 103);
            ResetBtn.FlatStyle = FlatStyle.Popup;
            ResetBtn.ForeColor = Color.FromArgb(241, 246, 249);
            ResetBtn.Location = new Point(240, 360);
            ResetBtn.Margin = new Padding(3, 4, 3, 4);
            ResetBtn.Name = "ResetBtn";
            ResetBtn.Size = new Size(86, 31);
            ResetBtn.TabIndex = 5;
            ResetBtn.Text = "Reset";
            ResetBtn.UseVisualStyleBackColor = false;
            ResetBtn.Click += ResetBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(33, 42, 62);
            label2.ForeColor = Color.FromArgb(241, 246, 249);
            label2.Location = new Point(23, 277);
            label2.Name = "label2";
            label2.Size = new Size(48, 20);
            label2.TabIndex = 7;
            label2.Text = "Hours";
            // 
            // HoursInput
            // 
            HoursInput.BackColor = Color.FromArgb(57, 72, 103);
            HoursInput.BorderStyle = BorderStyle.None;
            HoursInput.ForeColor = Color.FromArgb(241, 246, 249);
            HoursInput.Location = new Point(19, 301);
            HoursInput.Margin = new Padding(3, 4, 3, 4);
            HoursInput.Maximum = new decimal(new int[] { 24, 0, 0, 0 });
            HoursInput.Name = "HoursInput";
            HoursInput.Size = new Size(51, 23);
            HoursInput.TabIndex = 8;
            HoursInput.ValueChanged += NumericInput_Click;
            HoursInput.Click += NumericInput_Click;
            // 
            // MinutesInput
            // 
            MinutesInput.BackColor = Color.FromArgb(57, 72, 103);
            MinutesInput.BorderStyle = BorderStyle.None;
            MinutesInput.ForeColor = Color.FromArgb(241, 246, 249);
            MinutesInput.Location = new Point(88, 301);
            MinutesInput.Margin = new Padding(3, 4, 3, 4);
            MinutesInput.Maximum = new decimal(new int[] { 59, 0, 0, 0 });
            MinutesInput.Name = "MinutesInput";
            MinutesInput.Size = new Size(51, 23);
            MinutesInput.TabIndex = 10;
            MinutesInput.ValueChanged += NumericInput_Click;
            MinutesInput.Click += NumericInput_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(33, 42, 62);
            label1.ForeColor = Color.FromArgb(241, 246, 249);
            label1.Location = new Point(85, 277);
            label1.Name = "label1";
            label1.Size = new Size(61, 20);
            label1.TabIndex = 9;
            label1.Text = "Minutes";
            // 
            // SecondsInput
            // 
            SecondsInput.BackColor = Color.FromArgb(57, 72, 103);
            SecondsInput.BorderStyle = BorderStyle.None;
            SecondsInput.ForeColor = Color.FromArgb(241, 246, 249);
            SecondsInput.Location = new Point(159, 301);
            SecondsInput.Margin = new Padding(3, 4, 3, 4);
            SecondsInput.Maximum = new decimal(new int[] { 59, 0, 0, 0 });
            SecondsInput.Name = "SecondsInput";
            SecondsInput.Size = new Size(51, 23);
            SecondsInput.TabIndex = 12;
            SecondsInput.ValueChanged += NumericInput_Click;
            SecondsInput.Click += NumericInput_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(33, 42, 62);
            label3.ForeColor = Color.FromArgb(241, 246, 249);
            label3.Location = new Point(155, 277);
            label3.Name = "label3";
            label3.Size = new Size(64, 20);
            label3.TabIndex = 11;
            label3.Text = "Seconds";
            // 
            // OpenConsoleBtn
            // 
            OpenConsoleBtn.BackColor = Color.FromArgb(57, 72, 103);
            OpenConsoleBtn.FlatStyle = FlatStyle.Popup;
            OpenConsoleBtn.ForeColor = Color.FromArgb(241, 246, 249);
            OpenConsoleBtn.Location = new Point(13, 411);
            OpenConsoleBtn.Margin = new Padding(3, 4, 3, 4);
            OpenConsoleBtn.Name = "OpenConsoleBtn";
            OpenConsoleBtn.Size = new Size(197, 31);
            OpenConsoleBtn.TabIndex = 13;
            OpenConsoleBtn.Text = "Open native console";
            OpenConsoleBtn.UseVisualStyleBackColor = false;
            OpenConsoleBtn.Click += OpenConsoleBtn_Click;
            // 
            // ConsoleInput
            // 
            ConsoleInput.BackColor = Color.FromArgb(57, 72, 103);
            ConsoleInput.BorderStyle = BorderStyle.None;
            ConsoleInput.Enabled = false;
            ConsoleInput.ForeColor = Color.FromArgb(241, 246, 249);
            ConsoleInput.Location = new Point(14, 459);
            ConsoleInput.Name = "ConsoleInput";
            ConsoleInput.PlaceholderText = "Console mode";
            ConsoleInput.Size = new Size(569, 20);
            ConsoleInput.TabIndex = 14;
            ConsoleInput.KeyDown += ConsoleInputEnterKeydown;
            // 
            // ChangeSpeedInput
            // 
            ChangeSpeedInput.BackColor = Color.FromArgb(57, 72, 103);
            ChangeSpeedInput.BorderStyle = BorderStyle.None;
            ChangeSpeedInput.ForeColor = Color.FromArgb(241, 246, 249);
            ChangeSpeedInput.Location = new Point(250, 301);
            ChangeSpeedInput.Margin = new Padding(3, 4, 3, 4);
            ChangeSpeedInput.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            ChangeSpeedInput.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            ChangeSpeedInput.Name = "ChangeSpeedInput";
            ChangeSpeedInput.Size = new Size(51, 23);
            ChangeSpeedInput.TabIndex = 15;
            ChangeSpeedInput.Value = new decimal(new int[] { 1, 0, 0, 0 });
            ChangeSpeedInput.ValueChanged += SpeedChangedEvent;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(33, 42, 62);
            label4.ForeColor = Color.FromArgb(241, 246, 249);
            label4.Location = new Point(221, 277);
            label4.Name = "label4";
            label4.Size = new Size(118, 20);
            label4.TabIndex = 16;
            label4.Text = "Ticks per second";
            // 
            // millisecondsOutput
            // 
            millisecondsOutput.AutoSize = true;
            millisecondsOutput.BackColor = Color.FromArgb(33, 42, 62);
            millisecondsOutput.Font = new Font("Segoe UI", 45F, FontStyle.Regular, GraphicsUnit.Point);
            millisecondsOutput.ForeColor = Color.FromArgb(241, 246, 249);
            millisecondsOutput.Location = new Point(352, 83);
            millisecondsOutput.Name = "millisecondsOutput";
            millisecondsOutput.Size = new Size(67, 113);
            millisecondsOutput.TabIndex = 17;
            millisecondsOutput.Text = "0";
            millisecondsOutput.UseCompatibleTextRendering = true;
            // 
            // cutOutput
            // 
            cutOutput.Location = new Point(368, 245);
            cutOutput.Margin = new Padding(3, 4, 3, 4);
            cutOutput.Multiline = true;
            cutOutput.Name = "cutOutput";
            cutOutput.ReadOnly = true;
            cutOutput.ScrollBars = ScrollBars.Vertical;
            cutOutput.Size = new Size(215, 197);
            cutOutput.TabIndex = 18;
            // 
            // cutBtn
            // 
            cutBtn.BackColor = Color.FromArgb(57, 72, 103);
            cutBtn.FlatStyle = FlatStyle.Popup;
            cutBtn.ForeColor = Color.FromArgb(241, 246, 249);
            cutBtn.Location = new Point(240, 411);
            cutBtn.Margin = new Padding(3, 4, 3, 4);
            cutBtn.Name = "cutBtn";
            cutBtn.Size = new Size(86, 31);
            cutBtn.TabIndex = 19;
            cutBtn.Text = "Cut";
            cutBtn.UseVisualStyleBackColor = false;
            cutBtn.Click += CutBtn_click;
            // 
            // AnalogTimerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(33, 42, 62);
            ClientSize = new Size(595, 499);
            Controls.Add(cutBtn);
            Controls.Add(cutOutput);
            Controls.Add(millisecondsOutput);
            Controls.Add(outputLabel);
            Controls.Add(label4);
            Controls.Add(ChangeSpeedInput);
            Controls.Add(ConsoleInput);
            Controls.Add(OpenConsoleBtn);
            Controls.Add(SecondsInput);
            Controls.Add(label3);
            Controls.Add(MinutesInput);
            Controls.Add(label1);
            Controls.Add(HoursInput);
            Controls.Add(label2);
            Controls.Add(ResetBtn);
            Controls.Add(TimerTypeComboBox);
            Controls.Add(PauseBtn);
            Controls.Add(StartBtn);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "AnalogTimerForm";
            Text = "Not so Analog Timer";
            ((System.ComponentModel.ISupportInitialize)HoursInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)MinutesInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)SecondsInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)ChangeSpeedInput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label outputLabel;
        private Button StartBtn;
        private Button PauseBtn;
        private ComboBox TimerTypeComboBox;
        private Button ResetBtn;
        private Label label2;
        private NumericUpDown HoursInput;
        private NumericUpDown MinutesInput;
        private Label label1;
        private NumericUpDown SecondsInput;
        private Label label3;
        private Button OpenConsoleBtn;
        private TextBox ConsoleInput;
        private NumericUpDown ChangeSpeedInput;
        private Label label4;
        private Label millisecondsOutput;
        private ColorDialog colorDialog1;
        private TextBox cutOutput;
        private Button cutBtn;
    }
}