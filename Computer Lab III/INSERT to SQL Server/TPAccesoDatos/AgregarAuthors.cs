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
    public partial class AgregarAuthors : Form
    {
        public AgregarAuthors()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Author a = new Author();
                a.Id = txtbxID.Text;
                a.Nombre = txtbxNombre.Text;
                a.Apellido = txtbxApellido.Text;
                a.Telefono = txtbxTelefono.Text;
                a.Direccion = txtbxDireccion.Text;
                a.Ciudad = txtbxCiudad.Text;
                a.Provincia = txtbxProvincia.Text;
                a.CodigoPostal = txtbxCodigoPostal.Text;
                a.Contrato = txtbxContrato.Text;
                Gestor g = new Gestor();
                g.insertarAuthor(a);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            
        }
    }
}
