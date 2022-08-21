namespace ReadSequentialAccessFile
{
    partial class ReadSequentialAccessFileForm
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
            this.nextButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(400, 400);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(140, 32);
            this.nextButton.TabIndex = 11;
            this.nextButton.Text = "Next Record";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(240, 400);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(140, 32);
            this.openButton.TabIndex = 10;
            this.openButton.Text = "Open File";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // ReadSequentialAccessFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 461);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.openButton);
            this.Name = "ReadSequentialAccessFileForm";
            this.Text = "Form1";
            this.Controls.SetChildIndex(this.openButton, 0);
            this.Controls.SetChildIndex(this.nextButton, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button openButton;
    }
}

