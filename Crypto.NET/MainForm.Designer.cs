namespace Crypto.NET
{
    partial class MainForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.ExtractFileButton = new System.Windows.Forms.Button();
            this.MainGroupBox = new System.Windows.Forms.GroupBox();
            this.ArchiveFileButton = new System.Windows.Forms.Button();
            this.DeleteFileButton = new System.Windows.Forms.Button();
            this.FileNameBox = new System.Windows.Forms.ListBox();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewArchiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenArchiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExtractAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseArchiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainGroupBox.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExtractFileButton
            // 
            this.ExtractFileButton.Location = new System.Drawing.Point(6, 203);
            this.ExtractFileButton.Name = "ExtractFileButton";
            this.ExtractFileButton.Size = new System.Drawing.Size(202, 25);
            this.ExtractFileButton.TabIndex = 1;
            this.ExtractFileButton.Text = "Wypakuj";
            this.ExtractFileButton.UseVisualStyleBackColor = true;
            this.ExtractFileButton.Click += new System.EventHandler(this.ExtractFileButton_Clicked);
            // 
            // MainGroupBox
            // 
            this.MainGroupBox.Controls.Add(this.ArchiveFileButton);
            this.MainGroupBox.Controls.Add(this.DeleteFileButton);
            this.MainGroupBox.Controls.Add(this.FileNameBox);
            this.MainGroupBox.Controls.Add(this.ExtractFileButton);
            this.MainGroupBox.Location = new System.Drawing.Point(12, 27);
            this.MainGroupBox.Name = "MainGroupBox";
            this.MainGroupBox.Size = new System.Drawing.Size(220, 267);
            this.MainGroupBox.TabIndex = 4;
            this.MainGroupBox.TabStop = false;
            this.MainGroupBox.Text = "Pliki w archiwum";
            // 
            // ArchiveFileButton
            // 
            this.ArchiveFileButton.Location = new System.Drawing.Point(6, 172);
            this.ArchiveFileButton.Name = "ArchiveFileButton";
            this.ArchiveFileButton.Size = new System.Drawing.Size(202, 25);
            this.ArchiveFileButton.TabIndex = 8;
            this.ArchiveFileButton.Text = "Dodaj";
            this.ArchiveFileButton.UseVisualStyleBackColor = true;
            this.ArchiveFileButton.Click += new System.EventHandler(this.ArchiveFileButton_Clicked);
            // 
            // DeleteFileButton
            // 
            this.DeleteFileButton.Location = new System.Drawing.Point(6, 234);
            this.DeleteFileButton.Name = "DeleteFileButton";
            this.DeleteFileButton.Size = new System.Drawing.Size(202, 23);
            this.DeleteFileButton.TabIndex = 7;
            this.DeleteFileButton.Text = "Usuń";
            this.DeleteFileButton.UseVisualStyleBackColor = true;
            this.DeleteFileButton.Click += new System.EventHandler(this.DeleteFileButton_Clicked);
            // 
            // FileNameBox
            // 
            this.FileNameBox.FormattingEnabled = true;
            this.FileNameBox.Location = new System.Drawing.Point(6, 19);
            this.FileNameBox.Name = "FileNameBox";
            this.FileNameBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.FileNameBox.Size = new System.Drawing.Size(202, 147);
            this.FileNameBox.TabIndex = 3;
            this.FileNameBox.SelectedIndexChanged += new System.EventHandler(this.FileNameBoxSelectedIndex_Changed);
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(239, 24);
            this.MenuStrip.TabIndex = 5;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewArchiveToolStripMenuItem,
            this.OpenArchiveToolStripMenuItem,
            this.ExtractAllToolStripMenuItem,
            this.DeleteAllToolStripMenuItem,
            this.CloseArchiveToolStripMenuItem,
            this.AboutToolStripMenuItem,
            this.QuitToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.FileToolStripMenuItem.Text = "Plik";
            // 
            // NewArchiveToolStripMenuItem
            // 
            this.NewArchiveToolStripMenuItem.Name = "NewArchiveToolStripMenuItem";
            this.NewArchiveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.NewArchiveToolStripMenuItem.Text = "Nowe archiwum";
            this.NewArchiveToolStripMenuItem.Click += new System.EventHandler(this.NewArchiveToolstripMenuItem_Clicked);
            // 
            // OpenArchiveToolStripMenuItem
            // 
            this.OpenArchiveToolStripMenuItem.Name = "OpenArchiveToolStripMenuItem";
            this.OpenArchiveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.OpenArchiveToolStripMenuItem.Text = "Otwórz";
            this.OpenArchiveToolStripMenuItem.Click += new System.EventHandler(this.OpenArchiveToolstripMenuItem_Clicked);
            // 
            // ExtractAllToolStripMenuItem
            // 
            this.ExtractAllToolStripMenuItem.Name = "ExtractAllToolStripMenuItem";
            this.ExtractAllToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ExtractAllToolStripMenuItem.Text = "Wypakuj całość";
            this.ExtractAllToolStripMenuItem.Click += new System.EventHandler(this.ExtractAllToolstripMenuItem_Clicked);
            // 
            // DeleteAllToolStripMenuItem
            // 
            this.DeleteAllToolStripMenuItem.Name = "DeleteAllToolStripMenuItem";
            this.DeleteAllToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.DeleteAllToolStripMenuItem.Text = "Wyczyść archiwum";
            this.DeleteAllToolStripMenuItem.Click += new System.EventHandler(this.DeleteAllToolstripMenuItem_Clicked);
            // 
            // CloseArchiveToolStripMenuItem
            // 
            this.CloseArchiveToolStripMenuItem.Name = "CloseArchiveToolStripMenuItem";
            this.CloseArchiveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.CloseArchiveToolStripMenuItem.Text = "Zamknij";
            this.CloseArchiveToolStripMenuItem.Click += new System.EventHandler(this.CloseArchiveToolstripMenuItem_Clicked);
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.AboutToolStripMenuItem.Text = "O programie";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolstripMenuItem_Clicked);
            // 
            // QuitToolStripMenuItem
            // 
            this.QuitToolStripMenuItem.Name = "QuitToolStripMenuItem";
            this.QuitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.QuitToolStripMenuItem.Text = "Zakończ";
            this.QuitToolStripMenuItem.Click += new System.EventHandler(this.QuitToolstripMenuItem_Clicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 299);
            this.Controls.Add(this.MainGroupBox);
            this.Controls.Add(this.MenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.MenuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crypto.NET";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_Closing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainGroupBox.ResumeLayout(false);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ExtractFileButton;
        private System.Windows.Forms.GroupBox MainGroupBox;
        private System.Windows.Forms.ListBox FileNameBox;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewArchiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenArchiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem QuitToolStripMenuItem;
        private System.Windows.Forms.Button DeleteFileButton;
        private System.Windows.Forms.ToolStripMenuItem CloseArchiveToolStripMenuItem;
        private System.Windows.Forms.Button ArchiveFileButton;
        private System.Windows.Forms.ToolStripMenuItem ExtractAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteAllToolStripMenuItem;
    }
}

