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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ArchiveFileButton = new System.Windows.Forms.Button();
            this.DeleteFileButton = new System.Windows.Forms.Button();
            this.fileNameBox = new System.Windows.Forms.ListBox();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.MenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewArchiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenArchiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExtractAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseArchiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2.SuspendLayout();
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
            this.ExtractFileButton.Click += new System.EventHandler(this.ExtractFileButtonClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ArchiveFileButton);
            this.groupBox2.Controls.Add(this.DeleteFileButton);
            this.groupBox2.Controls.Add(this.fileNameBox);
            this.groupBox2.Controls.Add(this.ExtractFileButton);
            this.groupBox2.Location = new System.Drawing.Point(12, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(220, 267);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pliki";
            // 
            // ArchiveFileButton
            // 
            this.ArchiveFileButton.Location = new System.Drawing.Point(6, 172);
            this.ArchiveFileButton.Name = "ArchiveFileButton";
            this.ArchiveFileButton.Size = new System.Drawing.Size(202, 25);
            this.ArchiveFileButton.TabIndex = 8;
            this.ArchiveFileButton.Text = "Dodaj";
            this.ArchiveFileButton.UseVisualStyleBackColor = true;
            this.ArchiveFileButton.Click += new System.EventHandler(this.ArchiveFileButtonClick);
            // 
            // DeleteFileButton
            // 
            this.DeleteFileButton.Location = new System.Drawing.Point(6, 234);
            this.DeleteFileButton.Name = "DeleteFileButton";
            this.DeleteFileButton.Size = new System.Drawing.Size(202, 23);
            this.DeleteFileButton.TabIndex = 7;
            this.DeleteFileButton.Text = "Usuń";
            this.DeleteFileButton.UseVisualStyleBackColor = true;
            this.DeleteFileButton.Click += new System.EventHandler(this.DeleteFileButtonClick);
            // 
            // fileNameBox
            // 
            this.fileNameBox.FormattingEnabled = true;
            this.fileNameBox.Location = new System.Drawing.Point(6, 19);
            this.fileNameBox.Name = "fileNameBox";
            this.fileNameBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.fileNameBox.Size = new System.Drawing.Size(202, 147);
            this.fileNameBox.TabIndex = 3;
            this.fileNameBox.SelectedIndexChanged += new System.EventHandler(this.FileNameBoxSelectedIndexChanged);
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(239, 24);
            this.MenuStrip.TabIndex = 5;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // MenuToolStripMenuItem
            // 
            this.MenuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewArchiveToolStripMenuItem,
            this.OpenArchiveToolStripMenuItem,
            this.ExtractAllToolStripMenuItem,
            this.DeleteAllToolStripMenuItem,
            this.CloseArchiveToolStripMenuItem,
            this.AboutToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem";
            this.MenuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.MenuToolStripMenuItem.Text = "Menu";
            // 
            // NewArchiveToolStripMenuItem
            // 
            this.NewArchiveToolStripMenuItem.Name = "NewArchiveToolStripMenuItem";
            this.NewArchiveToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.NewArchiveToolStripMenuItem.Text = "Nowe archiwum";
            this.NewArchiveToolStripMenuItem.Click += new System.EventHandler(this.NewArchiveToolstripMenuItemClick);
            // 
            // OpenArchiveToolStripMenuItem
            // 
            this.OpenArchiveToolStripMenuItem.Name = "OpenArchiveToolStripMenuItem";
            this.OpenArchiveToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.OpenArchiveToolStripMenuItem.Text = "Otwórz";
            this.OpenArchiveToolStripMenuItem.Click += new System.EventHandler(this.OpenArchiveToolstripMenuItemClick);
            // 
            // ExtractAllToolStripMenuItem
            // 
            this.ExtractAllToolStripMenuItem.Name = "ExtractAllToolStripMenuItem";
            this.ExtractAllToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.ExtractAllToolStripMenuItem.Text = "Wypakuj całość";
            this.ExtractAllToolStripMenuItem.Click += new System.EventHandler(this.ExtractAllToolstripMenuItemClick);
            // 
            // DeleteAllToolStripMenuItem
            // 
            this.DeleteAllToolStripMenuItem.Name = "DeleteAllToolStripMenuItem";
            this.DeleteAllToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.DeleteAllToolStripMenuItem.Text = "Wyczyść archiwum";
            this.DeleteAllToolStripMenuItem.Click += new System.EventHandler(this.DeleteAllToolstripMenuItemClick);
            // 
            // CloseArchiveToolStripMenuItem
            // 
            this.CloseArchiveToolStripMenuItem.Name = "CloseArchiveToolStripMenuItem";
            this.CloseArchiveToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.CloseArchiveToolStripMenuItem.Text = "Zamknij";
            this.CloseArchiveToolStripMenuItem.Click += new System.EventHandler(this.CloseArchiveToolstripMenuItemClick);
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.AboutToolStripMenuItem.Text = "O programie";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolstripMenuItemClick);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.quitToolStripMenuItem.Text = "Zakończ";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.QuitToolstripMenuItemClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 299);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.MenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.MenuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crypto.NET";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ExtractFileButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox fileNameBox;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem MenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewArchiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenArchiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.Button DeleteFileButton;
        private System.Windows.Forms.ToolStripMenuItem CloseArchiveToolStripMenuItem;
        private System.Windows.Forms.Button ArchiveFileButton;
        private System.Windows.Forms.ToolStripMenuItem ExtractAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteAllToolStripMenuItem;
    }
}

