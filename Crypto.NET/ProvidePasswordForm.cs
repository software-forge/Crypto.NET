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
    public partial class ProvidePasswordForm : Form
    {
        public string Password { get; private set; }

        public ProvidePasswordForm()
        {
            InitializeComponent();

            Password = "";
        }

        private void ProvidePasswordForm_Load(object sender, EventArgs e) { }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            Password = "";
            Close();
        }

        private void OkButtonClick(object sender, EventArgs e)
        {
            Password = passwordBox.Text;
            Close();
        }
    }
}
