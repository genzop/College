using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Parcial_AccesoDatos.Clases;

namespace Parcial_AccesoDatos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnMostrarTabla_Click(object sender, EventArgs e)
        {
            Gestor gestor = new Gestor();
            DataTable dt = gestor.mostrarTabla();
            dgvArticulos.DataSource = dt;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Articulo articulo = new Articulo();
            articulo.Codigo = Convert.ToInt32(txtCodigo.Text);
            articulo.Denominacion = txtDenominacion.Text;
            articulo.Rubro = txtRubro.Text;
            articulo.Stock = Convert.ToInt32(txtStock.Text);

            Gestor gestor = new Gestor();
            gestor.insertar(articulo);
            DataTable dt = gestor.mostrarTabla();
            dgvArticulos.DataSource = dt;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo articulo = new Articulo();
            articulo.Codigo = Convert.ToInt32(txtCodigo.Text);
            articulo.Denominacion = txtDenominacion.Text;
            articulo.Rubro = txtRubro.Text;
            articulo.Stock = Convert.ToInt32(txtStock.Text);
            Gestor gestor = new Gestor();
            gestor.modificar(articulo);
            DataTable dt = gestor.mostrarTabla();
            dgvArticulos.DataSource = dt;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Articulo articulo = new Articulo();
            articulo.Codigo = Convert.ToInt32(txtCodigo.Text);
            articulo.Denominacion = txtDenominacion.Text;
            articulo.Rubro = txtRubro.Text;
            articulo.Stock = Convert.ToInt32(txtStock.Text);
            Gestor gestor = new Gestor();
            gestor.eliminar(articulo);
            DataTable dt = gestor.mostrarTabla();
            dgvArticulos.DataSource = dt;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
