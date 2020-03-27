using System;

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
            DialogResult = DialogResult.OK;
            Close();
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
            Compression = CompressionCheckBox.Checked;
        }

        private void VerifyInput()
        {
            string password = PasswordBox.Text;
            string passwordConfirm = ConfirmBox.Text;

            if(password.Equals("") || passwordConfirm.Equals(""))
            {
                OkButton.Enabled = false;
            }
            else if(!password.Equals(passwordConfirm))
            {
                OkButton.Enabled = false;
            }
            else
            {
                Password = password;
                OkButton.Enabled = true;
            }
        }

        private void PasswordBoxTextChanged(object sender, EventArgs e)
        {
            VerifyInput();
        }

        private void PasswordConfirmBoxTextChanged(object sender, EventArgs e)
        {
            VerifyInput();
        }
    }
}
