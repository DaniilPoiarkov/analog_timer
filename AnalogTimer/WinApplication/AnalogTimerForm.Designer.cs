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
            ErrorOutput = new TextBox();
            ((System.ComponentModel.ISupportInitialize)HoursInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MinutesInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SecondsInput).BeginInit();
            SuspendLayout();
            // 
            // outputLabel
            // 
            outputLabel.AutoSize = true;
            outputLabel.Location = new Point(148, 196);
            outputLabel.Name = "outputLabel";
            outputLabel.Size = new Size(39, 20);
            outputLabel.TabIndex = 0;
            outputLabel.Text = "_____";
            // 
            // StartBtn
            // 
            StartBtn.Location = new Point(19, 503);
            StartBtn.Margin = new Padding(3, 4, 3, 4);
            StartBtn.Name = "StartBtn";
            StartBtn.Size = new Size(86, 31);
            StartBtn.TabIndex = 1;
            StartBtn.Text = "Start";
            StartBtn.UseVisualStyleBackColor = true;
            StartBtn.Click += StartBtn_Click;
            // 
            // PauseBtn
            // 
            PauseBtn.Location = new Point(130, 503);
            PauseBtn.Margin = new Padding(3, 4, 3, 4);
            PauseBtn.Name = "PauseBtn";
            PauseBtn.Size = new Size(86, 31);
            PauseBtn.TabIndex = 2;
            PauseBtn.Text = "Pause";
            PauseBtn.UseVisualStyleBackColor = true;
            PauseBtn.Click += PauseBtn_Click;
            // 
            // TimerTypeComboBox
            // 
            TimerTypeComboBox.FormattingEnabled = true;
            TimerTypeComboBox.Items.AddRange(new object[] { "Timer", "Stopwatch" });
            TimerTypeComboBox.Location = new Point(14, 220);
            TimerTypeComboBox.Margin = new Padding(3, 4, 3, 4);
            TimerTypeComboBox.Name = "TimerTypeComboBox";
            TimerTypeComboBox.Size = new Size(173, 28);
            TimerTypeComboBox.TabIndex = 4;
            TimerTypeComboBox.SelectedValueChanged += TimerTypeChanged;
            // 
            // ResetBtn
            // 
            ResetBtn.Location = new Point(246, 503);
            ResetBtn.Margin = new Padding(3, 4, 3, 4);
            ResetBtn.Name = "ResetBtn";
            ResetBtn.Size = new Size(86, 31);
            ResetBtn.TabIndex = 5;
            ResetBtn.Text = "Reset";
            ResetBtn.UseVisualStyleBackColor = true;
            ResetBtn.Click += ResetBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 277);
            label2.Name = "label2";
            label2.Size = new Size(48, 20);
            label2.TabIndex = 7;
            label2.Text = "Hours";
            // 
            // HoursInput
            // 
            HoursInput.Location = new Point(19, 301);
            HoursInput.Margin = new Padding(3, 4, 3, 4);
            HoursInput.Maximum = new decimal(new int[] { 24, 0, 0, 0 });
            HoursInput.Name = "HoursInput";
            HoursInput.Size = new Size(51, 27);
            HoursInput.TabIndex = 8;
            HoursInput.Click += HoursInput_Click;
            // 
            // MinutesInput
            // 
            MinutesInput.Location = new Point(78, 301);
            MinutesInput.Margin = new Padding(3, 4, 3, 4);
            MinutesInput.Maximum = new decimal(new int[] { 59, 0, 0, 0 });
            MinutesInput.Name = "MinutesInput";
            MinutesInput.Size = new Size(51, 27);
            MinutesInput.TabIndex = 10;
            MinutesInput.Click += MinutesInput_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(74, 277);
            label1.Name = "label1";
            label1.Size = new Size(61, 20);
            label1.TabIndex = 9;
            label1.Text = "Minutes";
            // 
            // SecondsInput
            // 
            SecondsInput.Location = new Point(136, 301);
            SecondsInput.Margin = new Padding(3, 4, 3, 4);
            SecondsInput.Maximum = new decimal(new int[] { 59, 0, 0, 0 });
            SecondsInput.Name = "SecondsInput";
            SecondsInput.Size = new Size(51, 27);
            SecondsInput.TabIndex = 12;
            SecondsInput.Click += SecondsInput_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(133, 277);
            label3.Name = "label3";
            label3.Size = new Size(64, 20);
            label3.TabIndex = 11;
            label3.Text = "Seconds";
            // 
            // OpenConsoleBtn
            // 
            OpenConsoleBtn.Location = new Point(19, 553);
            OpenConsoleBtn.Margin = new Padding(3, 4, 3, 4);
            OpenConsoleBtn.Name = "OpenConsoleBtn";
            OpenConsoleBtn.Size = new Size(197, 31);
            OpenConsoleBtn.TabIndex = 13;
            OpenConsoleBtn.Text = "Open native console";
            OpenConsoleBtn.UseVisualStyleBackColor = true;
            OpenConsoleBtn.Click += OpenConsoleBtn_Click;
            // 
            // ErrorOutput
            // 
            ErrorOutput.Location = new Point(203, 220);
            ErrorOutput.Multiline = true;
            ErrorOutput.Name = "ErrorOutput";
            ErrorOutput.Size = new Size(309, 108);
            ErrorOutput.TabIndex = 14;
            // 
            // AnalogTimerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(535, 600);
            Controls.Add(ErrorOutput);
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
            Controls.Add(outputLabel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AnalogTimerForm";
            Text = "Not so Analog Timer";
            ((System.ComponentModel.ISupportInitialize)HoursInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)MinutesInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)SecondsInput).EndInit();
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
        private TextBox ErrorOutput;
    }
}