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
    public partial class Options : Form
    {
        Pilas pil = new Pilas();
        Listas list = new Listas();
        Colas cola = new Colas();
        public Options()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pil.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cola.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            list.Show();
            this.Hide();
        }

        private void formularioPilaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pil.Show();
            this.Hide();
        }

        private void formularioColaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cola.Show();
            this.Hide();
        }

        private void formularioListaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            list.Show();
            this.Hide();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }
    }
}
