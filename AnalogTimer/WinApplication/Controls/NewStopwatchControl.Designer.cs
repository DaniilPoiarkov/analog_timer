namespace WinApplication
{
    partial class NewStopwatchControl
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
            cutOutput = new TextBox();
            StopwatchMsOutput = new Label();
            label5 = new Label();
            StopwatchOutput = new Label();
            StopwatchResetBtn = new Button();
            StopwatchStartBtn = new Button();
            SuspendLayout();
            // 
            // cutOutput
            // 
            cutOutput.Location = new Point(11, 122);
            cutOutput.Margin = new Padding(3, 4, 3, 4);
            cutOutput.Multiline = true;
            cutOutput.Name = "cutOutput";
            cutOutput.ReadOnly = true;
            cutOutput.ScrollBars = ScrollBars.Vertical;
            cutOutput.Size = new Size(326, 160);
            cutOutput.TabIndex = 36;
            // 
            // StopwatchMsOutput
            // 
            StopwatchMsOutput.AutoSize = true;
            StopwatchMsOutput.BackColor = Color.FromArgb(33, 42, 62);
            StopwatchMsOutput.Font = new Font("Segoe UI", 35F, FontStyle.Regular, GraphicsUnit.Point);
            StopwatchMsOutput.ForeColor = Color.FromArgb(241, 246, 249);
            StopwatchMsOutput.Location = new Point(265, 0);
            StopwatchMsOutput.Name = "StopwatchMsOutput";
            StopwatchMsOutput.Size = new Size(52, 88);
            StopwatchMsOutput.TabIndex = 35;
            StopwatchMsOutput.Text = "0";
            StopwatchMsOutput.UseCompatibleTextRendering = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(33, 42, 62);
            label5.ForeColor = Color.FromArgb(241, 246, 249);
            label5.Location = new Point(12, 98);
            label5.Name = "label5";
            label5.Size = new Size(47, 20);
            label5.TabIndex = 37;
            label5.Text = "Leaps";
            // 
            // StopwatchOutput
            // 
            StopwatchOutput.AutoSize = true;
            StopwatchOutput.BackColor = Color.FromArgb(33, 42, 62);
            StopwatchOutput.Font = new Font("Segoe UI", 35F, FontStyle.Regular, GraphicsUnit.Point);
            StopwatchOutput.ForeColor = Color.FromArgb(241, 246, 249);
            StopwatchOutput.Location = new Point(0, 0);
            StopwatchOutput.Name = "StopwatchOutput";
            StopwatchOutput.Size = new Size(286, 88);
            StopwatchOutput.TabIndex = 30;
            StopwatchOutput.Text = "00:00:00:0";
            StopwatchOutput.UseCompatibleTextRendering = true;
            // 
            // StopwatchResetBtn
            // 
            StopwatchResetBtn.BackColor = Color.FromArgb(57, 72, 103);
            StopwatchResetBtn.Enabled = false;
            StopwatchResetBtn.FlatStyle = FlatStyle.Popup;
            StopwatchResetBtn.ForeColor = Color.FromArgb(241, 246, 249);
            StopwatchResetBtn.Location = new Point(181, 290);
            StopwatchResetBtn.Margin = new Padding(3, 4, 3, 4);
            StopwatchResetBtn.Name = "StopwatchResetBtn";
            StopwatchResetBtn.Size = new Size(160, 31);
            StopwatchResetBtn.TabIndex = 32;
            StopwatchResetBtn.Text = "Reset";
            StopwatchResetBtn.UseVisualStyleBackColor = false;
            StopwatchResetBtn.Click += RightBtnCLick;
            // 
            // StopwatchStartBtn
            // 
            StopwatchStartBtn.BackColor = Color.FromArgb(57, 72, 103);
            StopwatchStartBtn.FlatStyle = FlatStyle.Popup;
            StopwatchStartBtn.ForeColor = Color.FromArgb(241, 246, 249);
            StopwatchStartBtn.Location = new Point(12, 290);
            StopwatchStartBtn.Margin = new Padding(3, 4, 3, 4);
            StopwatchStartBtn.Name = "StopwatchStartBtn";
            StopwatchStartBtn.Size = new Size(160, 31);
            StopwatchStartBtn.TabIndex = 31;
            StopwatchStartBtn.Text = "Start";
            StopwatchStartBtn.UseVisualStyleBackColor = false;
            StopwatchStartBtn.Click += SwitchStopwatchClick;
            // 
            // NewStopwatchControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(33, 42, 62);
            Controls.Add(cutOutput);
            Controls.Add(StopwatchMsOutput);
            Controls.Add(label5);
            Controls.Add(StopwatchOutput);
            Controls.Add(StopwatchResetBtn);
            Controls.Add(StopwatchStartBtn);
            Name = "NewStopwatchControl";
            Size = new Size(345, 334);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox cutOutput;
        private Label StopwatchMsOutput;
        private Label label5;
        private Label StopwatchOutput;
        private Button StopwatchResetBtn;
        private Button StopwatchStartBtn;
    }
}
