namespace Crypto.NET
{
    partial class NewArchiveForm
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
            this.TitleLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.ConfirmLabel = new System.Windows.Forms.Label();
            this.ConfirmBox = new System.Windows.Forms.TextBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.CompressionCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TitleLabel.Location = new System.Drawing.Point(110, 9);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(115, 16);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Nowe archiwum";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(68, 50);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(39, 13);
            this.PasswordLabel.TabIndex = 1;
            this.PasswordLabel.Text = "Hasło:";
            // 
            // PasswordBox
            // 
            this.PasswordBox.Location = new System.Drawing.Point(113, 47);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.PasswordChar = '*';
            this.PasswordBox.Size = new System.Drawing.Size(200, 20);
            this.PasswordBox.TabIndex = 2;
            this.PasswordBox.TextChanged += new System.EventHandler(this.PasswordBoxTextChanged);
            // 
            // ConfirmLabel
            // 
            this.ConfirmLabel.AutoSize = true;
            this.ConfirmLabel.Location = new System.Drawing.Point(21, 82);
            this.ConfirmLabel.Name = "ConfirmLabel";
            this.ConfirmLabel.Size = new System.Drawing.Size(86, 13);
            this.ConfirmLabel.TabIndex = 3;
            this.ConfirmLabel.Text = "Potwierdź hasło:";
            // 
            // ConfirmBox
            // 
            this.ConfirmBox.Location = new System.Drawing.Point(113, 79);
            this.ConfirmBox.Name = "ConfirmBox";
            this.ConfirmBox.PasswordChar = '*';
            this.ConfirmBox.Size = new System.Drawing.Size(200, 20);
            this.ConfirmBox.TabIndex = 4;
            this.ConfirmBox.TextChanged += new System.EventHandler(this.PasswordConfirmBoxTextChanged);
            // 
            // OkButton
            // 
            this.OkButton.Enabled = false;
            this.OkButton.Location = new System.Drawing.Point(238, 140);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 5;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButtonClick);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(24, 140);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 6;
            this.CancelButton.Text = "Anuluj";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // CompressionCheckBox
            // 
            this.CompressionCheckBox.AutoSize = true;
            this.CompressionCheckBox.Location = new System.Drawing.Point(113, 115);
            this.CompressionCheckBox.Name = "CompressionCheckBox";
            this.CompressionCheckBox.Size = new System.Drawing.Size(96, 17);
            this.CompressionCheckBox.TabIndex = 7;
            this.CompressionCheckBox.Text = "Kompresuj pliki";
            this.CompressionCheckBox.UseVisualStyleBackColor = true;
            this.CompressionCheckBox.CheckedChanged += new System.EventHandler(this.CompressFilesCheckboxCheckedChanged);
            // 
            // NewArchiveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 179);
            this.Controls.Add(this.CompressionCheckBox);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.ConfirmBox);
            this.Controls.Add(this.ConfirmLabel);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.TitleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NewArchiveForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.PasswordDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.Label ConfirmLabel;
        private System.Windows.Forms.TextBox ConfirmBox;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.CheckBox CompressionCheckBox;
    }
}