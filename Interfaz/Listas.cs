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
    public partial class Listas : Form
    {
        List<ListaEstudiante> MiLista = new List<ListaEstudiante>();
        public Listas()
        {
            InitializeComponent();
            txtId.Focus();
        }

        private void ClearBox()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtEdad.Clear();
            cbEstrato.SelectedIndex = -1;
            cbPrograma.SelectedIndex = -1;
            cbUniversidad.SelectedIndex = -1;
            txtId.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }

        private void tsmSalir_Click(object sender, EventArgs e)
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

        private void tsmRegresar_Click(object sender, EventArgs e)
        {
            Options opt = new Options();
            opt.Show();
            this.Hide();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtEdad.Text == "" || txtId.Text == "" || txtNombre.Text == "" || cbEstrato.Text == "" || cbPrograma.Text == "" || cbUniversidad.Text == "")
            {
                MessageBox.Show("Todos los campos son requeridos");
                txtId.Focus();
            }
            else
            {
                ListaEstudiante lista = new ListaEstudiante();
                lista.Identificacón = txtId.Text;
                lista.Nombre = txtNombre.Text;
                lista.Edad = txtEdad.Text;
                lista.Estrato = cbEstrato.Text;
                lista.Programa = cbPrograma.Text;
                lista.Universidad = cbUniversidad.Text;
                lista.Fecha = dtFecha.Value;
                MiLista.Add(lista);
                dgvLista.DataSource = null;
                dgvLista.DataSource = MiLista;
                txtRegistros.Text = MiLista.Count.ToString();
                MessageBox.Show("Datos agregados con exito");
                ClearBox();
            }
        }

        private void tsmAgregar_Click(object sender, EventArgs e)
        {
            if (txtEdad.Text == "" || txtId.Text == "" || txtNombre.Text == "" || cbEstrato.Text == "" || cbPrograma.Text == "" || cbUniversidad.Text == "")
            {
                MessageBox.Show("Todos los campos son requeridos");
                txtId.Focus();
            }
            else
            {
                ListaEstudiante lista = new ListaEstudiante();
                lista.Identificacón = txtId.Text;
                lista.Nombre = txtNombre.Text;
                lista.Edad = txtEdad.Text;
                lista.Estrato = cbEstrato.Text;
                lista.Programa = cbPrograma.Text;
                lista.Universidad = cbUniversidad.Text;
                lista.Fecha = dtFecha.Value;
                MiLista.Add(lista);
                dgvLista.DataSource = null;
                dgvLista.DataSource = MiLista;
                txtRegistros.Text = MiLista.Count.ToString();
                MessageBox.Show("Datos agregados con exito");
                ClearBox();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MiLista.Count != 0)
            {
                if (txtId.Text != "")
                {                    
                    if (MessageBox.Show("¿Desea Eliminar el usuario? "+txtNombre.Text, "ATENCIÓN",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        foreach (ListaEstudiante lista in MiLista)
                            {
                            if(lista.Identificacón == txtId.Text)
                            {
                                MiLista.Remove(lista);
                                break;
                            }
                            }
                        dgvLista.DataSource = null;
                        dgvLista.DataSource = MiLista;
                        MessageBox.Show("Dato eliminado");
                        ClearBox();
                    }
                    
                    else
                    {
                        MessageBox.Show("No Se encontro el estudiante");
                        ClearBox();
                    }
                }            
                else
                {
                    MessageBox.Show("El campo Identificacion esta vacio");
                    txtId.Focus();
                }
            }
            else
            {
                MessageBox.Show("No hay datos en la tabla");
                txtId.Focus();
            }
        }

        private ListaEstudiante GetEstudiante(string id)
        {
            return MiLista.Find(estudiante => estudiante.Identificacón.Contains(id));
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (MiLista.Count != 0)
            {
                if (txtId.Text != "")
                {
                    ListaEstudiante lista = GetEstudiante(txtId.Text);
                    if (lista != null)
                    {                        
                            txtId.Text = lista.Identificacón;
                            txtNombre.Text = lista.Nombre;
                            txtEdad.Text = lista.Edad;
                            cbEstrato.Text = lista.Estrato;
                            cbPrograma.Text = lista.Programa;
                            cbUniversidad.Text = lista.Universidad;
                            dtFecha.Value = lista.Fecha;
                        MessageBox.Show("Estudiante encontrado, Su identificacion es: "+txtId.Text+" Nombre: "+txtNombre.Text+
                            " Edad: "+txtEdad.Text+" Estrato: "+cbEstrato.Text+" Programa: "+cbPrograma.Text+" Universidad "
                            +cbUniversidad.Text+" Fecha Inscripción: "+dtFecha.Value);
                        ClearBox();
                    }
                    else
                    {
                        MessageBox.Show("No se encontro el estudiante");
                        ClearBox();
                    }
                }
                else
                {
                    MessageBox.Show("El campo Identificacion esta vacio");
                    txtId.Focus();
                }
            }
            else
            {
                MessageBox.Show("No hay datos en la tabla");
                txtId.Focus();
            }
        }

        private void tsmEliminar_Click(object sender, EventArgs e)
        {
            if (MiLista.Count != 0)
            {
                if (txtId.Text != "")
                {
                    if (MessageBox.Show("¿Desea Eliminar el usuario? " + txtNombre.Text, "ATENCIÓN",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        foreach (ListaEstudiante lista in MiLista)
                        {
                            if (lista.Identificacón == txtId.Text)
                            {
                                MiLista.Remove(lista);
                                break;
                            }
                        }
                        dgvLista.DataSource = null;
                        dgvLista.DataSource = MiLista;
                        MessageBox.Show("Dato eliminado");
                        ClearBox();
                    }

                    else
                    {
                        MessageBox.Show("No Se encontro el estudiante");
                        ClearBox();
                    }
                }
                else
                {
                    MessageBox.Show("El campo Identificacion esta vacio");
                    txtId.Focus();
                }
            }
            else
            {
                MessageBox.Show("No hay datos en la tabla");
                txtId.Focus();
            }
        }

        private void tsmProximo_Click(object sender, EventArgs e)
        {
            if (MiLista.Count != 0)
            {
                if (txtId.Text != "")
                {
                    ListaEstudiante lista = GetEstudiante(txtId.Text);
                    if (lista != null)
                    {
                        txtId.Text = lista.Identificacón;
                        txtNombre.Text = lista.Nombre;
                        txtEdad.Text = lista.Edad;
                        cbEstrato.Text = lista.Estrato;
                        cbPrograma.Text = lista.Programa;
                        cbUniversidad.Text = lista.Universidad;
                        dtFecha.Value = lista.Fecha;
                        MessageBox.Show("Estudiante encontrado, Su identificacion es: " + txtId.Text + " Nombre: " + txtNombre.Text +
                            " Edad: " + txtEdad.Text + " Estrato: " + cbEstrato.Text + " Programa: " + cbPrograma.Text + " Universidad "
                            + cbUniversidad.Text + " Fecha Inscripción: " + dtFecha.Value);
                        ClearBox();
                    }
                    else
                    {
                        MessageBox.Show("No se encontro el estudiante");
                        ClearBox();
                    }
                }
                else
                {
                    MessageBox.Show("El campo Identificacion esta vacio");
                    txtId.Focus();
                }
            }
            else
            {
                MessageBox.Show("No hay datos en la tabla");
                txtId.Focus();
            }
        }
    }
}
