using System;
using System.Windows.Forms;

using LibCrypto.NET.Encryption;

namespace Crypto.NET
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();

            DescriptionLabel.Text = "Program stanowi temat pracy dyplomowej napisanej pod kierunkiem mgr inż. Waldemara Ptasznika-Kisielińskiego" +
                "\n                                                      w Warszawskiej Wyższej Szkole Informatyki.";
            CopyrightLabel.Text = string.Format("{0} Rafał Miller 2020", Convert.ToChar(169));

            Pbkdf2Label.Text = string.Format("Ilość iteracji funkcji PBKDF2: {0}", EncryptionKey.Iterations);
            KeyLengthLabel.Text = string.Format("Długość klucza AES: {0} bitów", EncryptionKey.KeyLength * 8);
        }

        private void OkButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {

        }
    }
}
