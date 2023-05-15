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
            button2 = new Button();
            comboBox1 = new ComboBox();
            button3 = new Button();
            label2 = new Label();
            numericMins = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numericMins).BeginInit();
            SuspendLayout();
            // 
            // outputLabel
            // 
            outputLabel.AutoSize = true;
            outputLabel.Location = new Point(12, 9);
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
            // button2
            // 
            button2.Location = new Point(114, 368);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 2;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Timer", "Stopwatch" });
            comboBox1.Location = new Point(12, 38);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(172, 23);
            comboBox1.TabIndex = 4;
            // 
            // button3
            // 
            button3.Location = new Point(215, 368);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 5;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 208);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 7;
            label2.Text = "Minutes";
            // 
            // numericMins
            // 
            numericMins.Location = new Point(17, 226);
            numericMins.Name = "numericMins";
            numericMins.Size = new Size(45, 23);
            numericMins.TabIndex = 8;
            numericMins.Click += numericMins_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(468, 450);
            Controls.Add(numericMins);
            Controls.Add(label2);
            Controls.Add(button3);
            Controls.Add(comboBox1);
            Controls.Add(button2);
            Controls.Add(StartBtn);
            Controls.Add(outputLabel);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numericMins).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label outputLabel;
        private Button StartBtn;
        private Button button2;
        private ComboBox comboBox1;
        private Button button3;
        private Label label2;
        private NumericUpDown numericMins;
    }
}