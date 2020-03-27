using System;
using System.Collections.Generic;
using System.Windows.Forms;

using LibCrypto.NET.Archivization;
using LibCrypto.NET.Encryption;

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

        AboutForm AboutForm;

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

            AboutForm = new AboutForm();
        }

        private void UpdateGui()
        {
            UpdateButtonState();
            UpdateListBox();
        }

        private void UpdateListBox()
        {
            if (WorkingArchive != null)
            {
                List<string> filenames = WorkingArchive.FileList;

                FileNameBox.BeginUpdate();
                FileNameBox.Items.Clear();
                foreach (string fname in filenames)
                    FileNameBox.Items.Add(fname);
                FileNameBox.EndUpdate();
            }
        }

        private void UpdateButtonState()
        {
            if (WorkingArchive != null && WorkingArchive.IsOpen)
            {
                ExtractAllToolStripMenuItem.Enabled = true;
                DeleteAllToolStripMenuItem.Enabled = true;
                CloseArchiveToolStripMenuItem.Enabled = true;

                ArchiveFileButton.Enabled = true;

                if (FileNameBox.SelectedItems.Count > 0)
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateButtonState();
        }

        private void MainForm_Closing(object sender, FormClosingEventArgs e)
        {
            if (WorkingArchive != null)
            {
                WorkingArchive.Close();
            }
        }

        private void ArchiveFileButton_Clicked(object sender, EventArgs e)
        {
            if(ArchiveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = ArchiveFileDialog.FileName;

                try
                {
                    WorkingArchive.ArchiveFile(filepath);
                }
                catch(FileNamingException fne)
                {
                    MessageBox.Show(string.Format("{0} Nadaj plikowi unikalną nazwę i spróbuj ponownie.", fne.Message), "Wystąpił błąd", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                
                UpdateListBox();
            }
        }

        private void ExtractFileButton_Clicked(object sender, EventArgs e)
        { 
            if(ExtractFolderDialog.ShowDialog() == DialogResult.OK)
            {
                foreach(string item in FileNameBox.SelectedItems)
                {
                    WorkingArchive.Extract(item, ExtractFolderDialog.SelectedPath);
                }
            }
        }

        private void DeleteFileButton_Clicked(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Czy na pewno chcesz usunąć wybrane pliki?", "Potwierdź usunięcie plików", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if(result == DialogResult.OK)
            {
                foreach(string name in FileNameBox.SelectedItems)
                {
                    WorkingArchive.Delete(name);
                }

                UpdateListBox();
            }
        }

        private void NewArchiveToolstripMenuItem_Clicked(object sender, EventArgs e)
        {
            if (CreateArchiveDialog.ShowDialog() == DialogResult.Cancel)
                return;

            if (NewArchiveForm.ShowDialog() == DialogResult.Cancel)
                return;

            string filename = CreateArchiveDialog.FileName;
            string password = NewArchiveForm.Password;
            bool compression = NewArchiveForm.Compression;

            // Jeżeli bieżące archiwum istnieje i jest otwarte, zamknięcie go
            if (WorkingArchive != null)
                WorkingArchive.Close();

            // Utworzenie nowego archiwum
            WorkingArchive = FileArchive.Create(filename, password, compression);

            UpdateGui();
        }

        private void OpenArchiveToolstripMenuItem_Clicked(object sender, EventArgs e)
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
                backup = WorkingArchive.Clone();
                WorkingArchive.Close();
            }

            try
            {
                // Próba otwarcia archiwum z użyciem podanego hasła
                WorkingArchive = FileArchive.Open(filename, password);
            }
            catch (KeyDerivationException kde)
            {
                // Próba otwarcia archiwum z użyciem podanego hasła nie powiodła się

                // Komunikat
                MessageBox.Show(kde.Message, "Wystąpił błąd", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                //Przywrócenie z zachowanej kopii dotychczas otwartego archiwum (jeżeli takie było)
                if (backup != null)
                    WorkingArchive = backup;
            }

            UpdateGui();
        }

        private void ExtractAllToolstripMenuItem_Clicked(object sender, EventArgs e)
        { 
            if (ExtractFolderDialog.ShowDialog() == DialogResult.OK)
            {
                WorkingArchive.ExtractAll(ExtractFolderDialog.SelectedPath);
            }      
        }

        private void DeleteAllToolstripMenuItem_Clicked(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Czy na pewno chcesz usunąć wszystkie pliki z archiwum?", "Potwierdź usunięcie plików", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.OK)
            {
                WorkingArchive.DeleteAll();
                UpdateListBox();
            }
        }

        private void CloseArchiveToolstripMenuItem_Clicked(object sender, EventArgs e)
        {
            if(WorkingArchive != null)
            {
                WorkingArchive.Close();
                UpdateGui();
            }
        }

        private void AboutToolstripMenuItem_Clicked(object sender, EventArgs e)
        {
            AboutForm.ShowDialog();
        }

        private void QuitToolstripMenuItem_Clicked(object sender, EventArgs e)
        {
            if(WorkingArchive != null)
            {
                WorkingArchive.Close();
            }
                
            Application.Exit();
        }

        private void FileNameBoxSelectedIndex_Changed(object sender, EventArgs e)
        {
            UpdateButtonState();
        }
    }
}
