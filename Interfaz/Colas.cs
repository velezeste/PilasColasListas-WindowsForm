using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PilasColasListas.Mundo;

namespace PilasColasListas
{
    public partial class Colas : Form
    {
        Queue<ColaAeroCivil> AeroVuelos = new Queue<ColaAeroCivil>();
        public Colas()
        {
            InitializeComponent();
            txtVuelo.Focus();
        }

        private void ClearBox()
        {
            txtVuelo.Clear();
            txtId.Clear();
            txtNombre.Clear();
            cbAero.SelectedIndex = -1;
            cbDestino.SelectedIndex = -1;
            txtVuelo.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Options opt = new Options();
            opt.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tsmSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }

        private void tsmRegresar_Click(object sender, EventArgs e)
        {
            Options opt = new Options();
            opt.Show();
            this.Hide();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtVuelo.Text == "" || txtId.Text == "" || txtNombre.Text == "" || cbAero.Text == "" || cbDestino.Text == "")
            {
                MessageBox.Show("Todos los campos son requeridos");
            }
            else
            {
                ColaAeroCivil MiCola = new ColaAeroCivil();
                MiCola.Vuelo = txtVuelo.Text;
                MiCola.Identificacón = txtId.Text;
                MiCola.Nombre = txtNombre.Text;
                MiCola.Aerolinea = cbAero.Text;
                MiCola.Destino = cbDestino.Text;
                MiCola.Fecha = dtFecha.Value;
                AeroVuelos.Enqueue(MiCola);
                dgvCola.DataSource = null;
                dgvCola.DataSource = AeroVuelos.ToList();
                txtRegistros.Text = AeroVuelos.Count.ToString();
                MessageBox.Show("Datos agregados con exito");
                ClearBox();
                    }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (AeroVuelos.Count != 0)
            {
                if (MessageBox.Show("¿Desea Eliminar el primer valor ingresado?", "ATENCIÓN",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    ColaAeroCivil MiCola = new ColaAeroCivil();
                    MiCola = AeroVuelos.Dequeue();
                    txtVuelo.Text = MiCola.Vuelo;
                    txtId.Text = MiCola.Identificacón;
                    txtNombre.Text = MiCola.Nombre;
                    cbAero.Text = MiCola.Aerolinea;
                    cbDestino.Text = MiCola.Destino;
                    dtFecha.Value = MiCola.Fecha;
                    dgvCola.DataSource = AeroVuelos.ToList();
                    txtRegistros.Text = AeroVuelos.Count.ToString();
                    MessageBox.Show("Se ha eliminado el primer dato ingresado en la cola");
                    ClearBox();
                }
            }
            else
            {
                MessageBox.Show("No hay datos en la tabla");
            }
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            if (AeroVuelos.Count != 0)
            {
                ColaAeroCivil MiCola = new ColaAeroCivil();
                MiCola = AeroVuelos.Peek();
                txtVuelo.Text = MiCola.Vuelo;
                txtId.Text = MiCola.Identificacón;
                txtNombre.Text = MiCola.Nombre;
                cbAero.Text = MiCola.Aerolinea;
                cbDestino.Text = MiCola.Destino;
                dtFecha.Value = MiCola.Fecha;
                dgvCola.DataSource = AeroVuelos.ToList();
                MessageBox.Show("El proximo dato a procesar es: No. Vuelo: " + txtVuelo.Text + " No. Identificacion: " + txtId.Text +
                    " Nombre: " + txtNombre.Text + " Aerolinea: " + cbAero.Text + " Destino " + cbDestino.Text +
                    " Fecha de Viaje: " + dtFecha.Value, "ATENCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearBox();
            }
            else
            {
                MessageBox.Show("No hay datos en la tabla");
            }
        }

        private void tsmAgregar_Click(object sender, EventArgs e)
        {
            if (txtVuelo.Text == "" || txtId.Text == "" || txtNombre.Text == "" || cbAero.Text == "" || cbDestino.Text == "")
            {
                MessageBox.Show("Todos los campos son requeridos");
            }
            else
            {
                ColaAeroCivil MiCola = new ColaAeroCivil();
                MiCola.Vuelo = txtVuelo.Text;
                MiCola.Identificacón = txtId.Text;
                MiCola.Nombre = txtNombre.Text;
                MiCola.Aerolinea = cbAero.Text;
                MiCola.Destino = cbDestino.Text;
                MiCola.Fecha = dtFecha.Value;
                AeroVuelos.Enqueue(MiCola);
                dgvCola.DataSource = null;
                dgvCola.DataSource = AeroVuelos.ToList();
                txtRegistros.Text = AeroVuelos.Count.ToString();
                MessageBox.Show("Datos agregados con exito");
                ClearBox();
            }
        }

        private void tsmEliminar_Click(object sender, EventArgs e)
        {
            if (AeroVuelos.Count != 0)
            {
                if (MessageBox.Show("¿Desea Eliminar el primer valor ingresado?", "ATENCIÓN",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    ColaAeroCivil MiCola = new ColaAeroCivil();
                    MiCola = AeroVuelos.Dequeue();
                    txtVuelo.Text = MiCola.Vuelo;
                    txtId.Text = MiCola.Identificacón;
                    txtNombre.Text = MiCola.Nombre;
                    cbAero.Text = MiCola.Aerolinea;
                    cbDestino.Text = MiCola.Destino;
                    dtFecha.Value = MiCola.Fecha;
                    dgvCola.DataSource = AeroVuelos.ToList();
                    txtRegistros.Text = AeroVuelos.Count.ToString();
                    MessageBox.Show("Se ha eliminado el primer dato ingresado en la cola");
                    ClearBox();
                }
            }
            else
            {
                MessageBox.Show("No hay datos en la tabla");
            }
        }

        private void tsmProximo_Click(object sender, EventArgs e)
        {
            if (AeroVuelos.Count != 0)
            {
                ColaAeroCivil MiCola = new ColaAeroCivil();
                MiCola = AeroVuelos.Peek();
                txtVuelo.Text = MiCola.Vuelo;
                txtId.Text = MiCola.Identificacón;
                txtNombre.Text = MiCola.Nombre;
                cbAero.Text = MiCola.Aerolinea;
                cbDestino.Text = MiCola.Destino;
                dtFecha.Value = MiCola.Fecha;
                dgvCola.DataSource = AeroVuelos.ToList();
                MessageBox.Show("El proximo dato a procesar es: No. Vuelo: " + txtVuelo.Text + " No. Identificacion: " + txtId.Text +
                    " Nombre: " + txtNombre.Text + " Aerolinea: " + cbAero.Text + " Destino " + cbDestino.Text +
                    " Fecha de Viaje: " + dtFecha.Value, "ATENCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearBox();
            }
            else
            {
                MessageBox.Show("No hay datos en la tabla");
            }
        }
    }
}
