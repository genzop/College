using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPAccesoDatos2.Clases;

namespace TPAccesoDatos2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pubsDataSet.publishers' table. You can move, or remove it, as needed.
            this.publishersTableAdapter.Fill(this.pubsDataSet.publishers);

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
           

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            try
            {
                Gestor gestor = new Gestor();
                DataTable dt = gestor.mostrarTabla();
                dgvPublishers.DataSource = dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Publisher publisher = new Publisher();
                publisher.Id = txtID.Text;
                Gestor gestor = new Gestor();
                gestor.eliminar(publisher);
                DataTable dt = gestor.mostrarTabla();
                dgvPublishers.DataSource = dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                Publisher publisher = new Publisher();
                publisher.Id = txtID.Text;
                publisher.Nombre = txtNombre.Text;
                publisher.Ciudad = txtCiudad.Text;
                publisher.Provincia = txtProvincia.Text;
                publisher.Pais = txtPais.Text;
                Gestor gestor = new Gestor();
                gestor.insertar(publisher);
                DataTable dt = gestor.mostrarTabla();
                dgvPublishers.DataSource = dt;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Publisher publisher = new Publisher();
                publisher.Id = txtID.Text;
                publisher.Nombre = txtNombre.Text;
                publisher.Ciudad = txtCiudad.Text;
                publisher.Provincia = txtProvincia.Text;
                publisher.Pais = txtPais.Text;
                Gestor gestor = new Gestor();
                gestor.modificar(publisher);
                DataTable dt = gestor.mostrarTabla();
                dgvPublishers.DataSource = dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
