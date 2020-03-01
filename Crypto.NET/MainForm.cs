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

        SetPasswordForm setPasswordForm;
        ProvidePasswordForm providePasswordForm;

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

            setPasswordForm = new SetPasswordForm();
            providePasswordForm = new ProvidePasswordForm();
        }

        private void MainForm_Load(object sender, EventArgs e) { }

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

        // TODO - przerobić po dodaniu opcji kompresji
        private void NewArchiveToolstripMenuItemClick(object sender, EventArgs e)
        {
            if(CreateArchiveDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = CreateArchiveDialog.FileName;

                setPasswordForm.ShowDialog();

                string password = setPasswordForm.Password;

                WorkingArchive = FileArchive.Create(filepath, password, false);

                UpdateListBox();
            }
        }

        // OK
        private void OpenArchiveToolstripMenuItemClick(object sender, EventArgs e)
        {
            if(OpenArchiveDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = OpenArchiveDialog.FileName;

                providePasswordForm.ShowDialog();

                string password = providePasswordForm.Password;

                try
                {
                    WorkingArchive = FileArchive.Open(filepath, password);
                }
                catch (KeyDerivationException)
                {
                    MessageBox.Show("Otwarcie archiwum przy użyciu podanego hasła nie powiodło się", "Błąd", MessageBoxButtons.OK);
                }

                UpdateListBox();
            }
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

        
    }
}
