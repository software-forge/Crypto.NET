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
    public partial class SetPasswordForm : Form
    {


        public string Password { get; private set; }

        public SetPasswordForm()
        {
            InitializeComponent();

            

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
                Close();
            }
        }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            Password = "";
            Close();
        }
    }
}
