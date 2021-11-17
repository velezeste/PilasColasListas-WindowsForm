using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PilasColasListas
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            password.Focus();
        }

        private void startlogin_Click(object sender, EventArgs e)
        {
            if (password.Text == "123")
            {
                Options opt = new Options();
                opt.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("" + "Contraseña inválida, ingrese una contraseña correcta", "Error");
                password.Clear();
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }
    }
}
