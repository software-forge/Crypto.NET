namespace Crypto.NET
{
    partial class PasswordInputForm
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
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TitleLabel.Location = new System.Drawing.Point(32, 9);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(184, 16);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Podaj hasło do archiwum";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(27, 47);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(39, 13);
            this.PasswordLabel.TabIndex = 1;
            this.PasswordLabel.Text = "Hasło:";
            // 
            // PasswordBox
            // 
            this.PasswordBox.Location = new System.Drawing.Point(72, 44);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.PasswordChar = '*';
            this.PasswordBox.Size = new System.Drawing.Size(148, 20);
            this.PasswordBox.TabIndex = 2;
            this.PasswordBox.TextChanged += new System.EventHandler(this.PasswordBoxTextChanged);
            // 
            // OkButton
            // 
            this.OkButton.Enabled = false;
            this.OkButton.Location = new System.Drawing.Point(145, 79);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 3;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButtonClick);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(30, 79);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 4;
            this.CancelButton.Text = "Anuluj";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // PasswordInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 120);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.TitleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PasswordInputForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ProvidePasswordForm";
            this.Load += new System.EventHandler(this.ProvidePasswordForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelButton;
    }
}