using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crypto.NET
{
    public partial class NewArchiveForm : Form
    {


        public string Password { get; private set; }

        public bool Compression { get; private set; }

        public NewArchiveForm()
        {
            InitializeComponent();

            Compression = false;
            Password = "";
        }

        private void PasswordDialog_Load(object sender, EventArgs e) { }

        private void OkButtonClick(object sender, EventArgs e)
        {
            string password = passwordBox.Text;
            string password_confirm = passwordConfirmBox.Text;

            if(password.Equals(password_confirm))
            {
                Password = password;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            Password = "";
            Compression = false;
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void CompressFilesCheckboxCheckedChanged(object sender, EventArgs e)
        {
            Compression = CompressFilesCheckbox.Checked;
        }
    }
}
