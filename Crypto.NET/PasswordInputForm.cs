using System;
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
    public partial class PasswordInputForm : Form
    {
        public string Password { get; private set; }

        public PasswordInputForm()
        {
            InitializeComponent();

            Password = "";
        }

        private void ProvidePasswordForm_Load(object sender, EventArgs e) { }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            Password = "";
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OkButtonClick(object sender, EventArgs e)
        {
            Password = passwordBox.Text;

            if (!Password.Equals(""))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
