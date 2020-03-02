using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Crypto.NET.Archivization;
using Crypto.NET.Encryption;

namespace Crypto.NET
{
    public partial class MainForm : Form
    {
        public FileArchive WorkingArchive { get; private set; }

        SaveFileDialog CreateArchiveDialog;
        OpenFileDialog OpenArchiveDialog;

        OpenFileDialog ArchiveFileDialog;

        FolderBrowserDialog ExtractFolderDialog;

        NewArchiveForm NewArchiveForm;
        PasswordInputForm PasswordInputForm;

        public MainForm()
        {
            InitializeComponent();

            CreateArchiveDialog = new SaveFileDialog();
            CreateArchiveDialog.Filter = "Pliki archiwum Crypto.NET | *.cdn";
            CreateArchiveDialog.DefaultExt = "cdn";

            OpenArchiveDialog = new OpenFileDialog();
            OpenArchiveDialog.Filter = "Pliki archiwum Crypto.NET | *.cdn";
            OpenArchiveDialog.DefaultExt = "cdn";

            ArchiveFileDialog = new OpenFileDialog();

            ExtractFolderDialog = new FolderBrowserDialog();

            NewArchiveForm = new NewArchiveForm();
            PasswordInputForm = new PasswordInputForm();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateButtonState();
        }

        private void MainFormClosing(object sender, FormClosingEventArgs e)
        {
            if (WorkingArchive != null)
            {
                WorkingArchive.Close();
            }
        }

        private void ArchiveFileButtonClick(object sender, EventArgs e)
        {
            if(ArchiveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = ArchiveFileDialog.FileName;

                WorkingArchive.ArchiveFile(filepath);
                
                UpdateListBox();
            }
        }

        // OK
        private void ExtractFileButtonClick(object sender, EventArgs e)
        { 
            if(ExtractFolderDialog.ShowDialog() == DialogResult.OK)
            {
                foreach(string item in fileNameBox.SelectedItems)
                {
                    WorkingArchive.Extract(item, ExtractFolderDialog.SelectedPath);
                }
            }
        }

        // OK
        private void DeleteFileButtonClick(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Czy na pewno chcesz usunąć wybrane pliki?", "Potwierdź usunięcie", MessageBoxButtons.OKCancel);

            if(result == DialogResult.OK)
            {
                foreach(string name in fileNameBox.SelectedItems)
                {
                    WorkingArchive.Delete(name);
                }

                UpdateListBox();
            }
        }

        // OK
        private void UpdateListBox()
        {
            if(WorkingArchive != null)
            {
                List<string> filenames = WorkingArchive.FileList;

                fileNameBox.BeginUpdate();
                fileNameBox.Items.Clear();
                foreach (string fname in filenames)
                    fileNameBox.Items.Add(fname);
                fileNameBox.EndUpdate();
            }
        }

        // OK
        private void UpdateButtonState()
        {
            if(WorkingArchive != null && WorkingArchive.IsOpen)
            {
                ExtractAllToolStripMenuItem.Enabled = true;
                DeleteAllToolStripMenuItem.Enabled = true;
                CloseArchiveToolStripMenuItem.Enabled = true;

                ArchiveFileButton.Enabled = true;

                if (fileNameBox.SelectedItems.Count > 0)
                {
                    ExtractFileButton.Enabled = true;
                    DeleteFileButton.Enabled = true;
                }
                else
                {
                    ExtractFileButton.Enabled = false;
                    DeleteFileButton.Enabled = false;
                }
            }
            else
            {
                ExtractAllToolStripMenuItem.Enabled = false;
                DeleteAllToolStripMenuItem.Enabled = false;
                CloseArchiveToolStripMenuItem.Enabled = false;
                ArchiveFileButton.Enabled = false;
                ExtractFileButton.Enabled = false;
                DeleteFileButton.Enabled = false;
            }
        }

        // TODO - przerobić po dodaniu opcji kompresji
        private void NewArchiveToolstripMenuItemClick(object sender, EventArgs e)
        {
            if (CreateArchiveDialog.ShowDialog() == DialogResult.Cancel)
                return;

            if (NewArchiveForm.ShowDialog() == DialogResult.Cancel)
                return;

            string filename = CreateArchiveDialog.FileName;
            string password = NewArchiveForm.Password;
            bool compression = NewArchiveForm.Compression;
            //bool compression = false;

            // Jeżeli bieżące archiwum istnieje i jest otwarte, zamknięcie go
            if (WorkingArchive != null)
                WorkingArchive.Close();

            // Utworzenie nowego archiwum
            WorkingArchive = FileArchive.Create(filename, password, compression);

            UpdateListBox();
            UpdateButtonState();
        }

        // OK
        private void OpenArchiveToolstripMenuItemClick(object sender, EventArgs e)
        {
            if (OpenArchiveDialog.ShowDialog() == DialogResult.Cancel)
                return;

            if (PasswordInputForm.ShowDialog() == DialogResult.Cancel)
                return;

            string filename = OpenArchiveDialog.FileName;
            string password = PasswordInputForm.Password;

            // Jeżeli bieżące archiwum istnieje i jest otwarte, przechowanie głębokiej kopii i bezpieczne zamknięcie go
            FileArchive backup = null;
            if (WorkingArchive != null)
            {
                backup = (FileArchive) WorkingArchive.Clone();
                WorkingArchive.Close();
            }

            try
            {
                // Próba otwarcia archiwum z użyciem podanego hasła
                WorkingArchive = FileArchive.Open(filename, password);
            }
            catch (KeyDerivationException)
            {
                // Próba otwarcia archiwum z użyciem podanego hasła nie powiodła się

                // Komunikat
                MessageBox.Show("Otwarcie archiwum przy użyciu podanego hasła nie powiodło się", "Błąd", MessageBoxButtons.OK);

                //Przywrócenie z zachowanej kopii dotychczas otwartego archiwum (jeżeli takie było)
                if (backup != null)
                    WorkingArchive = backup;
            }

            UpdateListBox();
            UpdateButtonState();
        }

        // OK
        private void ExtractAllToolstripMenuItemClick(object sender, EventArgs e)
        { 
            if (ExtractFolderDialog.ShowDialog() == DialogResult.OK)
            {
                WorkingArchive.ExtractAll(ExtractFolderDialog.SelectedPath);
            }      
        }

        // OK
        private void DeleteAllToolstripMenuItemClick(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Czy na pewno chcesz usunąć wszystkie pliki z archiwum?", "Potwierdź usunięcie", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                WorkingArchive.DeleteAll();
                UpdateListBox();
            }
        }

        // OK
        private void CloseArchiveToolstripMenuItemClick(object sender, EventArgs e)
        {
            if(WorkingArchive != null)
            {
                WorkingArchive.Close();
                UpdateListBox();
                UpdateButtonState();
            }
        }

        // TODO
        private void AboutToolstripMenuItemClick(object sender, EventArgs e) { }

        // OK
        private void QuitToolstripMenuItemClick(object sender, EventArgs e)
        {
            if(WorkingArchive != null)
            {
                WorkingArchive.Close();
            }
                
            Application.Exit();
        }

        private void FileNameBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtonState();
        }

       
    }
}
