using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPAccesoDatos.Clases;

namespace TPAccesoDatos
{
    public partial class TablaAuthors : Form
    {
        public TablaAuthors()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pubsDataSet.authors' table. You can move, or remove it, as needed.
            this.authorsTableAdapter.Fill(this.pubsDataSet.authors);

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarAuthors agregar = new AgregarAuthors();
            agregar.Show();       
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizarTabla_Click(object sender, EventArgs e)
        {
            try
            {
                Gestor g = new Gestor();
                DataTable dt = g.mostrarTabla();
                dgvAuthors.DataSource = dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
