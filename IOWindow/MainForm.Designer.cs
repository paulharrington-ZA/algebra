namespace IOWindow
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.xValueTextBox = new System.Windows.Forms.TextBox();
            this.yValueTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AddValuesButton = new System.Windows.Forms.Button();
            this.PointsListBox = new System.Windows.Forms.ListBox();
            this.RemovePointButton = new System.Windows.Forms.Button();
            this.EquationsRichTextBox = new System.Windows.Forms.RichTextBox();
            this.FittedCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // xValueTextBox
            // 
            this.xValueTextBox.Location = new System.Drawing.Point(50, 25);
            this.xValueTextBox.Name = "xValueTextBox";
            this.xValueTextBox.Size = new System.Drawing.Size(100, 20);
            this.xValueTextBox.TabIndex = 0;
            // 
            // yValueTextBox
            // 
            this.yValueTextBox.Location = new System.Drawing.Point(50, 52);
            this.yValueTextBox.Name = "yValueTextBox";
            this.yValueTextBox.Size = new System.Drawing.Size(100, 20);
            this.yValueTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "X Value";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Y Value";
            // 
            // AddValuesButton
            // 
            this.AddValuesButton.Location = new System.Drawing.Point(156, 50);
            this.AddValuesButton.Name = "AddValuesButton";
            this.AddValuesButton.Size = new System.Drawing.Size(75, 23);
            this.AddValuesButton.TabIndex = 4;
            this.AddValuesButton.Text = "Add Point";
            this.AddValuesButton.UseVisualStyleBackColor = true;
            this.AddValuesButton.Click += new System.EventHandler(this.AddValuesButton_Click);
            // 
            // PointsListBox
            // 
            this.PointsListBox.FormattingEnabled = true;
            this.PointsListBox.Location = new System.Drawing.Point(3, 81);
            this.PointsListBox.Name = "PointsListBox";
            this.PointsListBox.Size = new System.Drawing.Size(147, 173);
            this.PointsListBox.TabIndex = 5;
            // 
            // RemovePointButton
            // 
            this.RemovePointButton.Location = new System.Drawing.Point(157, 81);
            this.RemovePointButton.Name = "RemovePointButton";
            this.RemovePointButton.Size = new System.Drawing.Size(75, 37);
            this.RemovePointButton.TabIndex = 6;
            this.RemovePointButton.Text = "Remove Point";
            this.RemovePointButton.UseVisualStyleBackColor = true;
            this.RemovePointButton.Click += new System.EventHandler(this.RemovePointButton_Click);
            // 
            // EquationsRichTextBox
            // 
            this.EquationsRichTextBox.Location = new System.Drawing.Point(239, 81);
            this.EquationsRichTextBox.Name = "EquationsRichTextBox";
            this.EquationsRichTextBox.Size = new System.Drawing.Size(246, 173);
            this.EquationsRichTextBox.TabIndex = 7;
            this.EquationsRichTextBox.Text = "";
            // 
            // FittedCheckBox
            // 
            this.FittedCheckBox.AutoSize = true;
            this.FittedCheckBox.Location = new System.Drawing.Point(239, 54);
            this.FittedCheckBox.Name = "FittedCheckBox";
            this.FittedCheckBox.Size = new System.Drawing.Size(58, 17);
            this.FittedCheckBox.TabIndex = 8;
            this.FittedCheckBox.Text = "Fitted?";
            this.FittedCheckBox.UseVisualStyleBackColor = true;
            this.FittedCheckBox.CheckedChanged += new System.EventHandler(this.FittedCheckBox_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 396);
            this.Controls.Add(this.FittedCheckBox);
            this.Controls.Add(this.EquationsRichTextBox);
            this.Controls.Add(this.RemovePointButton);
            this.Controls.Add(this.PointsListBox);
            this.Controls.Add(this.AddValuesButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.yValueTextBox);
            this.Controls.Add(this.xValueTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox xValueTextBox;
        private System.Windows.Forms.TextBox yValueTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button AddValuesButton;
        private System.Windows.Forms.ListBox PointsListBox;
        private System.Windows.Forms.Button RemovePointButton;
        private System.Windows.Forms.RichTextBox EquationsRichTextBox;
        private System.Windows.Forms.CheckBox FittedCheckBox;
    }
}

