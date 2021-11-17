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
    public partial class Pilas : Form
    {
        Stack<PilaAcueducto> pilaAcueductos = new Stack<PilaAcueducto>();        
        public Pilas()
        {
            InitializeComponent();
            txtFactura.Focus();
        }
        
        private void button6_Click(object sender, EventArgs e)
        {
            PilaAcueducto MyPila = new PilaAcueducto();
            double d = MyPila.CalcularTotal(Double.Parse(txtMts.Text));
            txtTotal.Text = d.ToString();

        }

        private void txtMts_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(txtMts.Value == 0 || txtFactura.Text == "" || txtMatricula.Text == "" || cbMes.Text == "" || txtNombre.Text == "" || txtDireccion.Text == "" || cbEstrato.Text == "" || cbCategoria.Text == "" || txtTotal.Text == "") {
                MessageBox.Show("Todos los campos son requeridos");
            }
            else { 
            PilaAcueducto MyPila = new PilaAcueducto();
            MyPila.Factura = txtFactura.Text;
            MyPila.Matricula = txtMatricula.Text;
            MyPila.Mes = cbMes.Text;
            MyPila.Nombre = txtNombre.Text;
            MyPila.Direccion = txtDireccion.Text;
            MyPila.Estrato = cbEstrato.Text;
            MyPila.Categoria = cbCategoria.Text;
            MyPila.Metros = (double)txtMts.Value;
            MyPila.Total = Double.Parse(txtTotal.Text);
            MyPila.Fecha = dtFecha.Value;
            double Totalrecaudo = Double.Parse(txtRecaudado.Text);
            txtRecaudado.Text = MyPila.SumaRecaudo(Totalrecaudo, MyPila.Total).ToString();
            pilaAcueductos.Push(MyPila);
            dgvPila.DataSource = null;
            dgvPila.DataSource = pilaAcueductos.ToArray();
            MessageBox.Show("Datos agregados con exito");
            ClearBox();
            }
        }

        private void ClearBox()
        {
            txtFactura.Clear(); 
            txtMatricula.Clear();
            cbMes.SelectedIndex = -1;
            txtNombre.Clear(); 
            txtDireccion.Clear(); 
            cbEstrato.SelectedIndex = -1;
            cbCategoria.SelectedIndex = -1;
            txtMts.Value = 0; 
            txtTotal.Clear();
            txtFactura.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(pilaAcueductos.Count != 0)
            {
                if (MessageBox.Show("¿Desea Eliminar el ultimo valor ingresado?", "ATENCIÓN",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    PilaAcueducto MyPila = new PilaAcueducto();
                    MyPila = pilaAcueductos.Pop();
                    txtFactura.Text = MyPila.Factura;
                    txtMatricula.Text = MyPila.Matricula;
                    cbMes.Text = MyPila.Mes;
                    txtNombre.Text = MyPila.Nombre;
                    txtDireccion.Text = MyPila.Direccion;
                    cbEstrato.Text = MyPila.Estrato;
                    cbCategoria.Text = MyPila.Categoria;
                    txtMts.Value = (decimal)MyPila.Metros;
                    txtTotal.Text = MyPila.Total.ToString();
                    dtFecha.Value = MyPila.Fecha;
                    double resta = Double.Parse(txtRecaudado.Text) - Double.Parse(txtTotal.Text);
                    txtRecaudado.Text = resta.ToString();                    
                    dgvPila.DataSource = pilaAcueductos.ToArray();
                    MessageBox.Show("Se ha eliminado el ultimo dato ingresado en la pila");
                    ClearBox();
                }
            }
            else
            {
                MessageBox.Show("No hay datos en la tabla");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            if (pilaAcueductos.Count != 0)
            {
                PilaAcueducto MyPila = new PilaAcueducto();
            MyPila = pilaAcueductos.Peek();
            txtFactura.Text = MyPila.Factura;
            txtMatricula.Text = MyPila.Matricula;
            cbMes.Text = MyPila.Mes;
            txtNombre.Text = MyPila.Nombre;
            txtDireccion.Text = MyPila.Direccion;
            cbEstrato.Text = MyPila.Estrato;
            cbCategoria.Text = MyPila.Categoria;
            txtMts.Value = (decimal)MyPila.Metros;
            txtTotal.Text = MyPila.Total.ToString();
            dtFecha.Value = MyPila.Fecha;
            dgvPila.DataSource = pilaAcueductos.ToArray();
            MessageBox.Show("El proximo dato a procesar es: No. Factura: "+txtFactura.Text+ " No. Matricula: "+ txtMatricula.Text+
                " Mes Facturado: "+ cbMes.Text+" Nombre: "+txtNombre.Text+" Dirección "+ txtDireccion.Text+" Estrato "+cbEstrato.Text+
                " Categoria: "+cbCategoria.Text+" Metros cubicos "+txtMts.Value+" Valor: "+txtTotal.Text+" Fecha: "+dtFecha.Value,
                "ATENCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearBox();
            }
            else
            {
                MessageBox.Show("No hay datos en la tabla");
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Options opt = new Options();
            opt.Show();
            this.Hide();
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

        private void tsmAgregar_Click(object sender, EventArgs e)
        {
            if (txtMts.Value == 0 || txtFactura.Text == "" || txtMatricula.Text == "" || cbMes.Text == "" || txtNombre.Text == "" || txtDireccion.Text == "" || cbEstrato.Text == "" || cbCategoria.Text == "" || txtTotal.Text == "")
            {
                MessageBox.Show("Todos los campos son requeridos");
            }
            else
            {
                PilaAcueducto MyPila = new PilaAcueducto();
                MyPila.Factura = txtFactura.Text;
                MyPila.Matricula = txtMatricula.Text;
                MyPila.Mes = cbMes.Text;
                MyPila.Nombre = txtNombre.Text;
                MyPila.Direccion = txtDireccion.Text;
                MyPila.Estrato = cbEstrato.Text;
                MyPila.Categoria = cbCategoria.Text;
                MyPila.Metros = (double)txtMts.Value;
                MyPila.Total = Double.Parse(txtTotal.Text);
                MyPila.Fecha = dtFecha.Value;
                double Totalrecaudo = Double.Parse(txtRecaudado.Text);
                txtRecaudado.Text = MyPila.SumaRecaudo(Totalrecaudo, MyPila.Total).ToString();
                pilaAcueductos.Push(MyPila);
                dgvPila.DataSource = null;
                dgvPila.DataSource = pilaAcueductos.ToArray();
                MessageBox.Show("Datos agregados con exito");
                ClearBox();
            }
        }

        private void tsmEliminar_Click(object sender, EventArgs e)
        {
            if (pilaAcueductos.Count != 0)
            {
                if (MessageBox.Show("¿Desea Eliminar el ultimo valor ingresado?", "ATENCIÓN",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    PilaAcueducto MyPila = new PilaAcueducto();
                    MyPila = pilaAcueductos.Pop();
                    txtFactura.Text = MyPila.Factura;
                    txtMatricula.Text = MyPila.Matricula;
                    cbMes.Text = MyPila.Mes;
                    txtNombre.Text = MyPila.Nombre;
                    txtDireccion.Text = MyPila.Direccion;
                    cbEstrato.Text = MyPila.Estrato;
                    cbCategoria.Text = MyPila.Categoria;
                    txtMts.Value = (decimal)MyPila.Metros;
                    txtTotal.Text = MyPila.Total.ToString();
                    dtFecha.Value = MyPila.Fecha;
                    double resta = Double.Parse(txtRecaudado.Text) - Double.Parse(txtTotal.Text);
                    txtRecaudado.Text = resta.ToString();
                    dgvPila.DataSource = pilaAcueductos.ToArray();
                    MessageBox.Show("Se ha eliminado el ultimo dato ingresado en la pila");
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
            if (pilaAcueductos.Count != 0)
            {
                PilaAcueducto MyPila = new PilaAcueducto();
                MyPila = pilaAcueductos.Peek();
                txtFactura.Text = MyPila.Factura;
                txtMatricula.Text = MyPila.Matricula;
                cbMes.Text = MyPila.Mes;
                txtNombre.Text = MyPila.Nombre;
                txtDireccion.Text = MyPila.Direccion;
                cbEstrato.Text = MyPila.Estrato;
                cbCategoria.Text = MyPila.Categoria;
                txtMts.Value = (decimal)MyPila.Metros;
                txtTotal.Text = MyPila.Total.ToString();
                dtFecha.Value = MyPila.Fecha;
                dgvPila.DataSource = pilaAcueductos.ToArray();
                MessageBox.Show("El proximo dato a procesar es: No. Factura: " + txtFactura.Text + " No. Matricula: " + txtMatricula.Text +
                    " Mes Facturado: " + cbMes.Text + " Nombre: " + txtNombre.Text + " Dirección " + txtDireccion.Text + " Estrato " + cbEstrato.Text +
                    " Categoria: " + cbCategoria.Text + " Metros cubicos " + txtMts.Value + " Valor: " + txtTotal.Text + " Fecha: " + dtFecha.Value,
                    "ATENCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearBox();
            }
            else
            {
                MessageBox.Show("No hay datos en la tabla");
            }
        }
    }
}
