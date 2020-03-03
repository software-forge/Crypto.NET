namespace Crypto.NET
{
    partial class AboutForm
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
            this.OkButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.CopyrightLabel = new System.Windows.Forms.Label();
            this.Pbkdf2Label = new System.Windows.Forms.Label();
            this.KeyLengthLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(242, 182);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 0;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButtonClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Informacje o programie";
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(17, 59);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(58, 13);
            this.DescriptionLabel.TabIndex = 2;
            this.DescriptionLabel.Text = "description";
            // 
            // CopyrightLabel
            // 
            this.CopyrightLabel.AutoSize = true;
            this.CopyrightLabel.Location = new System.Drawing.Point(230, 100);
            this.CopyrightLabel.Name = "CopyrightLabel";
            this.CopyrightLabel.Size = new System.Drawing.Size(50, 13);
            this.CopyrightLabel.TabIndex = 3;
            this.CopyrightLabel.Text = "copyright";
            // 
            // Pbkdf2Label
            // 
            this.Pbkdf2Label.AutoSize = true;
            this.Pbkdf2Label.Location = new System.Drawing.Point(20, 128);
            this.Pbkdf2Label.Name = "Pbkdf2Label";
            this.Pbkdf2Label.Size = new System.Drawing.Size(146, 13);
            this.Pbkdf2Label.TabIndex = 4;
            this.Pbkdf2Label.Text = "Ilość iteracji funkcji PBKDF2: ";
            // 
            // KeyLengthLabel
            // 
            this.KeyLengthLabel.AutoSize = true;
            this.KeyLengthLabel.Location = new System.Drawing.Point(20, 153);
            this.KeyLengthLabel.Name = "KeyLengthLabel";
            this.KeyLengthLabel.Size = new System.Drawing.Size(109, 13);
            this.KeyLengthLabel.TabIndex = 5;
            this.KeyLengthLabel.Text = "Długość klucza AES:";
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 217);
            this.Controls.Add(this.KeyLengthLabel);
            this.Controls.Add(this.Pbkdf2Label);
            this.Controls.Add(this.CopyrightLabel);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OkButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AboutForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label CopyrightLabel;
        private System.Windows.Forms.Label Pbkdf2Label;
        private System.Windows.Forms.Label KeyLengthLabel;
    }
}