using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP___ABM_LINQ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            mostrarTabla();
        }

        public void mostrarTabla()
        {
            try
            {
                SuppliersDataContext db = new SuppliersDataContext();
                var proveedores = from prov in db.Suppliers
                                  select prov;
                dgvProveedores.DataSource = proveedores;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                Supplier proveedor = new Supplier();
                proveedor.SupplierID = Int32.Parse(txtID.Text);
                proveedor.CompanyName = txtNombreCompania.Text;
                proveedor.ContactName = txtNombreContacto.Text;
                proveedor.ContactTitle = txtTituloContacto.Text;
                proveedor.Address = txtDireccion.Text;
                proveedor.City = txtCiudad.Text;
                proveedor.Region = txtRegion.Text;
                proveedor.PostalCode = txtCodigoPostal.Text;
                proveedor.Country = txtPais.Text;
                proveedor.Phone = txtTelefono.Text;
                proveedor.Fax = txtFax.Text;
                proveedor.HomePage = txtPaginaInicio.Text;

                SuppliersDataContext db = new SuppliersDataContext();
                db.Suppliers.InsertOnSubmit(proveedor);
                db.SubmitChanges();
                mostrarTabla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {                
                SuppliersDataContext db = new SuppliersDataContext();

                if (txtID.Text != null)
                {
                    var proveedor = (from prov in db.Suppliers
                                     where prov.SupplierID == Int32.Parse(txtID.Text)
                                     select prov).Single();

                    proveedor.CompanyName = txtNombreCompania.Text;
                    proveedor.ContactName = txtNombreContacto.Text;
                    proveedor.ContactTitle = txtTituloContacto.Text;
                    proveedor.Address = txtDireccion.Text;
                    proveedor.City = txtCiudad.Text;
                    proveedor.Region = txtRegion.Text;
                    proveedor.PostalCode = txtCodigoPostal.Text;
                    proveedor.Country = txtPais.Text;
                    proveedor.Phone = txtTelefono.Text;
                    proveedor.Fax = txtFax.Text;
                    proveedor.HomePage = txtPaginaInicio.Text;
                    db.SubmitChanges();
                    mostrarTabla();
                }             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                SuppliersDataContext db = new SuppliersDataContext();

                if (txtID.Text != null)
                {
                    var proveedor = (from prov in db.Suppliers
                                     where prov.SupplierID == Int32.Parse(txtID.Text)
                                     select prov).Single();

                    db.Suppliers.DeleteOnSubmit(proveedor);
                    db.SubmitChanges();
                    mostrarTabla();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                SuppliersDataContext db = new SuppliersDataContext();
                if (txtBuscarXNombre.Text != null)
                {
                    var proveedores = from prov in db.Suppliers
                                      where prov.CompanyName == txtBuscarXNombre.Text
                                      select prov;
                    dgvProveedores.DataSource = proveedores;
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void btnActualizarTabla_Click(object sender, EventArgs e)
        {
            mostrarTabla();
        }
    }
}
