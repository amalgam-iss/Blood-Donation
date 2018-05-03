using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WpfProject;

namespace bloodDonor
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            Bitmap bmpIcon = bloodDonor.Properties.Resources.care;
            this.Icon = Icon.FromHandle(bmpIcon.GetHicon());
        }

        private void logInBtn_Click(object sender, EventArgs e)
        {
            if(passwordTextBox.Text !="" && userTextBox.Text != "")
            {
                MainWindow form = new MainWindow();
                form.Show();
            }
            else
            {
                MessageBox.Show(this, "Please make sure you added both a username and a password.", "Warning missing text", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
