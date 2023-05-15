namespace WinApplication
{
    partial class Form1
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
            comboBox1 = new ComboBox();
            ResetBtn = new Button();
            label2 = new Label();
            HoursInput = new NumericUpDown();
            MinutesInput = new NumericUpDown();
            label1 = new Label();
            SecondsInput = new NumericUpDown();
            label3 = new Label();
            OpenConsoleBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)HoursInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MinutesInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SecondsInput).BeginInit();
            SuspendLayout();
            // 
            // outputLabel
            // 
            outputLabel.AutoSize = true;
            outputLabel.Location = new Point(12, 62);
            outputLabel.Name = "outputLabel";
            outputLabel.Size = new Size(32, 15);
            outputLabel.TabIndex = 0;
            outputLabel.Text = "_____";
            // 
            // StartBtn
            // 
            StartBtn.Location = new Point(17, 368);
            StartBtn.Name = "StartBtn";
            StartBtn.Size = new Size(75, 23);
            StartBtn.TabIndex = 1;
            StartBtn.Text = "Start";
            StartBtn.UseVisualStyleBackColor = true;
            StartBtn.Click += StartBtn_Click;
            // 
            // PauseBtn
            // 
            PauseBtn.Location = new Point(114, 368);
            PauseBtn.Name = "PauseBtn";
            PauseBtn.Size = new Size(75, 23);
            PauseBtn.TabIndex = 2;
            PauseBtn.Text = "Pause";
            PauseBtn.UseVisualStyleBackColor = true;
            PauseBtn.Click += PauseBtn_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Timer", "Stopwatch" });
            comboBox1.Location = new Point(12, 165);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(172, 23);
            comboBox1.TabIndex = 4;
            // 
            // ResetBtn
            // 
            ResetBtn.Location = new Point(215, 368);
            ResetBtn.Name = "ResetBtn";
            ResetBtn.Size = new Size(75, 23);
            ResetBtn.TabIndex = 5;
            ResetBtn.Text = "Reset";
            ResetBtn.UseVisualStyleBackColor = true;
            ResetBtn.Click += ResetBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 208);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 7;
            label2.Text = "Hours";
            // 
            // HoursInput
            // 
            HoursInput.Location = new Point(17, 226);
            HoursInput.Name = "HoursInput";
            HoursInput.Size = new Size(45, 23);
            HoursInput.TabIndex = 8;
            HoursInput.Click += HoursInput_Click;
            // 
            // MinutesInput
            // 
            MinutesInput.Location = new Point(68, 226);
            MinutesInput.Name = "MinutesInput";
            MinutesInput.Size = new Size(45, 23);
            MinutesInput.TabIndex = 10;
            MinutesInput.Click += MinutesInput_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(65, 208);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 9;
            label1.Text = "Minutes";
            // 
            // SecondsInput
            // 
            SecondsInput.Location = new Point(119, 226);
            SecondsInput.Name = "SecondsInput";
            SecondsInput.Size = new Size(45, 23);
            SecondsInput.TabIndex = 12;
            SecondsInput.Click += SecondsInput_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(116, 208);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 11;
            label3.Text = "Seconds";
            // 
            // OpenConsoleBtn
            // 
            OpenConsoleBtn.Location = new Point(17, 415);
            OpenConsoleBtn.Name = "OpenConsoleBtn";
            OpenConsoleBtn.Size = new Size(142, 23);
            OpenConsoleBtn.TabIndex = 13;
            OpenConsoleBtn.Text = "Open native console";
            OpenConsoleBtn.UseVisualStyleBackColor = true;
            OpenConsoleBtn.Click += OpenConsoleBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(468, 450);
            Controls.Add(OpenConsoleBtn);
            Controls.Add(SecondsInput);
            Controls.Add(label3);
            Controls.Add(MinutesInput);
            Controls.Add(label1);
            Controls.Add(HoursInput);
            Controls.Add(label2);
            Controls.Add(ResetBtn);
            Controls.Add(comboBox1);
            Controls.Add(PauseBtn);
            Controls.Add(StartBtn);
            Controls.Add(outputLabel);
            Name = "Form1";
            Text = "Form1";
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
        private ComboBox comboBox1;
        private Button ResetBtn;
        private Label label2;
        private NumericUpDown HoursInput;
        private NumericUpDown MinutesInput;
        private Label label1;
        private NumericUpDown SecondsInput;
        private Label label3;
        private Button OpenConsoleBtn;
    }
}