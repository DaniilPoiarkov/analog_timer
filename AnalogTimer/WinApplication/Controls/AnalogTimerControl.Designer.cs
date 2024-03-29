﻿namespace WinApplication
{
    partial class AnalogTimerControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TimerStartTenSecBtn = new Button();
            TimerStartFiveMinBtn = new Button();
            TimerMsOutput = new Label();
            label6 = new Label();
            TimerOutput = new Label();
            MinutesInput = new NumericUpDown();
            TickPerSecondInput = new NumericUpDown();
            SwitchTimerBtn = new Button();
            TimerCaancelBtn = new Button();
            SecondsInput = new NumericUpDown();
            label9 = new Label();
            label7 = new Label();
            HoursInput = new NumericUpDown();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)MinutesInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TickPerSecondInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SecondsInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)HoursInput).BeginInit();
            SuspendLayout();
            // 
            // TimerStartTenSecBtn
            // 
            TimerStartTenSecBtn.BackColor = Color.FromArgb(57, 72, 103);
            TimerStartTenSecBtn.FlatStyle = FlatStyle.Popup;
            TimerStartTenSecBtn.ForeColor = Color.FromArgb(241, 246, 249);
            TimerStartTenSecBtn.Location = new Point(193, 131);
            TimerStartTenSecBtn.Name = "TimerStartTenSecBtn";
            TimerStartTenSecBtn.Size = new Size(102, 23);
            TimerStartTenSecBtn.TabIndex = 53;
            TimerStartTenSecBtn.Text = "Start 10 sec";
            TimerStartTenSecBtn.UseVisualStyleBackColor = false;
            TimerStartTenSecBtn.Click += StartTenSecondsBtnClick;
            // 
            // TimerStartFiveMinBtn
            // 
            TimerStartFiveMinBtn.BackColor = Color.FromArgb(57, 72, 103);
            TimerStartFiveMinBtn.FlatStyle = FlatStyle.Popup;
            TimerStartFiveMinBtn.ForeColor = Color.FromArgb(241, 246, 249);
            TimerStartFiveMinBtn.Location = new Point(10, 131);
            TimerStartFiveMinBtn.Name = "TimerStartFiveMinBtn";
            TimerStartFiveMinBtn.Size = new Size(102, 23);
            TimerStartFiveMinBtn.TabIndex = 52;
            TimerStartFiveMinBtn.Text = "Start 5 min";
            TimerStartFiveMinBtn.UseVisualStyleBackColor = false;
            TimerStartFiveMinBtn.Click += StartFiveMinutesBtnClick;
            // 
            // TimerMsOutput
            // 
            TimerMsOutput.AutoSize = true;
            TimerMsOutput.BackColor = Color.FromArgb(33, 42, 62);
            TimerMsOutput.Font = new Font("Segoe UI", 35F, FontStyle.Regular, GraphicsUnit.Point);
            TimerMsOutput.ForeColor = Color.FromArgb(241, 246, 249);
            TimerMsOutput.Location = new Point(211, 0);
            TimerMsOutput.Name = "TimerMsOutput";
            TimerMsOutput.Size = new Size(42, 71);
            TimerMsOutput.TabIndex = 40;
            TimerMsOutput.Text = "0";
            TimerMsOutput.UseCompatibleTextRendering = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.FromArgb(33, 42, 62);
            label6.ForeColor = Color.FromArgb(241, 246, 249);
            label6.Location = new Point(193, 176);
            label6.Name = "label6";
            label6.Size = new Size(94, 15);
            label6.TabIndex = 51;
            label6.Text = "Ticks per second";
            // 
            // TimerOutput
            // 
            TimerOutput.AutoSize = true;
            TimerOutput.BackColor = Color.FromArgb(33, 42, 62);
            TimerOutput.Font = new Font("Segoe UI", 35F, FontStyle.Regular, GraphicsUnit.Point);
            TimerOutput.ForeColor = Color.FromArgb(241, 246, 249);
            TimerOutput.Location = new Point(0, 0);
            TimerOutput.Name = "TimerOutput";
            TimerOutput.Size = new Size(229, 71);
            TimerOutput.TabIndex = 38;
            TimerOutput.Text = "00:00:00:0";
            TimerOutput.UseCompatibleTextRendering = true;
            // 
            // MinutesInput
            // 
            MinutesInput.BackColor = Color.FromArgb(57, 72, 103);
            MinutesInput.BorderStyle = BorderStyle.None;
            MinutesInput.ForeColor = Color.FromArgb(241, 246, 249);
            MinutesInput.Location = new Point(83, 194);
            MinutesInput.Maximum = new decimal(new int[] { 59, 0, 0, 0 });
            MinutesInput.Name = "MinutesInput";
            MinutesInput.Size = new Size(45, 19);
            MinutesInput.TabIndex = 45;
            MinutesInput.ValueChanged += NumericInput_Click;
            // 
            // TickPerSecondInput
            // 
            TickPerSecondInput.BackColor = Color.FromArgb(57, 72, 103);
            TickPerSecondInput.BorderStyle = BorderStyle.None;
            TickPerSecondInput.ForeColor = Color.FromArgb(241, 246, 249);
            TickPerSecondInput.Location = new Point(220, 194);
            TickPerSecondInput.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            TickPerSecondInput.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            TickPerSecondInput.Name = "TickPerSecondInput";
            TickPerSecondInput.Size = new Size(45, 19);
            TickPerSecondInput.TabIndex = 50;
            TickPerSecondInput.Value = new decimal(new int[] { 1, 0, 0, 0 });
            TickPerSecondInput.ValueChanged += SpeedChangedEvent;
            // 
            // SwitchTimerBtn
            // 
            SwitchTimerBtn.BackColor = Color.FromArgb(57, 72, 103);
            SwitchTimerBtn.FlatStyle = FlatStyle.Popup;
            SwitchTimerBtn.ForeColor = Color.FromArgb(241, 246, 249);
            SwitchTimerBtn.Location = new Point(10, 218);
            SwitchTimerBtn.Name = "SwitchTimerBtn";
            SwitchTimerBtn.Size = new Size(140, 23);
            SwitchTimerBtn.TabIndex = 39;
            SwitchTimerBtn.Text = "Start";
            SwitchTimerBtn.UseVisualStyleBackColor = false;
            SwitchTimerBtn.Click += SwitchTimerStateBtnClick;
            // 
            // TimerCaancelBtn
            // 
            TimerCaancelBtn.BackColor = Color.FromArgb(57, 72, 103);
            TimerCaancelBtn.Enabled = false;
            TimerCaancelBtn.FlatStyle = FlatStyle.Popup;
            TimerCaancelBtn.ForeColor = Color.FromArgb(241, 246, 249);
            TimerCaancelBtn.Location = new Point(158, 218);
            TimerCaancelBtn.Name = "TimerCaancelBtn";
            TimerCaancelBtn.Size = new Size(140, 23);
            TimerCaancelBtn.TabIndex = 41;
            TimerCaancelBtn.Text = "Cancel";
            TimerCaancelBtn.UseVisualStyleBackColor = false;
            TimerCaancelBtn.Click += CancelBtnClick;
            // 
            // SecondsInput
            // 
            SecondsInput.BackColor = Color.FromArgb(57, 72, 103);
            SecondsInput.BorderStyle = BorderStyle.None;
            SecondsInput.ForeColor = Color.FromArgb(241, 246, 249);
            SecondsInput.Location = new Point(149, 194);
            SecondsInput.Maximum = new decimal(new int[] { 59, 0, 0, 0 });
            SecondsInput.Name = "SecondsInput";
            SecondsInput.Size = new Size(45, 19);
            SecondsInput.TabIndex = 47;
            SecondsInput.ValueChanged += NumericInput_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.FromArgb(33, 42, 62);
            label9.ForeColor = Color.FromArgb(241, 246, 249);
            label9.Location = new Point(17, 176);
            label9.Name = "label9";
            label9.Size = new Size(39, 15);
            label9.TabIndex = 42;
            label9.Text = "Hours";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.FromArgb(33, 42, 62);
            label7.ForeColor = Color.FromArgb(241, 246, 249);
            label7.Location = new Point(137, 176);
            label7.Name = "label7";
            label7.Size = new Size(51, 15);
            label7.TabIndex = 46;
            label7.Text = "Seconds";
            // 
            // HoursInput
            // 
            HoursInput.BackColor = Color.FromArgb(57, 72, 103);
            HoursInput.BorderStyle = BorderStyle.None;
            HoursInput.ForeColor = Color.FromArgb(241, 246, 249);
            HoursInput.Location = new Point(14, 194);
            HoursInput.Maximum = new decimal(new int[] { 24, 0, 0, 0 });
            HoursInput.Name = "HoursInput";
            HoursInput.Size = new Size(45, 19);
            HoursInput.TabIndex = 43;
            HoursInput.ValueChanged += NumericInput_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.FromArgb(33, 42, 62);
            label8.ForeColor = Color.FromArgb(241, 246, 249);
            label8.Location = new Point(74, 176);
            label8.Name = "label8";
            label8.Size = new Size(50, 15);
            label8.TabIndex = 44;
            label8.Text = "Minutes";
            // 
            // AnalogTimerControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(33, 42, 62);
            Controls.Add(TimerStartTenSecBtn);
            Controls.Add(TimerStartFiveMinBtn);
            Controls.Add(TimerMsOutput);
            Controls.Add(label6);
            Controls.Add(TimerOutput);
            Controls.Add(MinutesInput);
            Controls.Add(TickPerSecondInput);
            Controls.Add(SwitchTimerBtn);
            Controls.Add(TimerCaancelBtn);
            Controls.Add(SecondsInput);
            Controls.Add(label9);
            Controls.Add(label7);
            Controls.Add(HoursInput);
            Controls.Add(label8);
            Margin = new Padding(3, 2, 3, 2);
            Name = "AnalogTimerControl";
            Size = new Size(302, 250);
            ((System.ComponentModel.ISupportInitialize)MinutesInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)TickPerSecondInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)SecondsInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)HoursInput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button TimerStartTenSecBtn;
        private Button TimerStartFiveMinBtn;
        private Label TimerMsOutput;
        private Label label6;
        private Label TimerOutput;
        private NumericUpDown MinutesInput;
        private NumericUpDown TickPerSecondInput;
        private Button SwitchTimerBtn;
        private Button TimerCaancelBtn;
        private NumericUpDown SecondsInput;
        private Label label9;
        private Label label7;
        private NumericUpDown HoursInput;
        private Label label8;
    }
}
