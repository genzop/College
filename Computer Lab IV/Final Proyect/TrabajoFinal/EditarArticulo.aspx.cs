using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditarArticulo : System.Web.UI.Page
{
    BaseDatosDataContext bd;

    protected void Page_Load(object sender, EventArgs e)
    {
        bd = new BaseDatosDataContext();

        if (Session["IdVendedor"] == null)
        {
            Response.Redirect("Ingresar.aspx");
        }
        else
        {
            if (Convert.ToInt32(Request.QueryString["id"]) == 0)
            {
                lblTitulo.Text = "Agregar Artículo";
                btnAccion.Text = "AGREGAR";
            }
            else
            {
                lblTitulo.Text = "Editar Artículo";
                btnAccion.Text = "GUARDAR";
                try
                {
                    var temp = (from art in bd.Articulos
                                where art.IdArticulo == Convert.ToInt32(Request.QueryString["id"])
                                select art).Single();

                    if (!IsPostBack)
                    {
                        txtDenominacion.Text = temp.Denominacion;
                        txtCodigo.Text = temp.Codigo;
                        txtPrecioCompra.Text = temp.PrecioCompra.ToString();
                        double iva = Convert.ToDouble(temp.Iva) * 100;
                        txtIVA.Text = iva.ToString();
                        txtPrecioVenta.Text = temp.PrecioVenta.ToString();
                        ddlRubro.SelectedValue = temp.IdRubro.ToString();
                    }
                }
                catch (Exception) { }               
            }
        }
    }

    protected void btnAccion_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                if (Convert.ToInt32(Request.QueryString["id"]) == 0)
                {
                    Articulo temp = new Articulo();
                    temp.Denominacion = txtDenominacion.Text;
                    temp.Codigo = txtCodigo.Text;
                    temp.PrecioCompra = Convert.ToDouble(txtPrecioCompra.Text);
                    double iva = Convert.ToDouble(txtIVA.Text) / 100;
                    temp.Iva = iva;
                    temp.PrecioVenta = Convert.ToDouble(txtPrecioVenta.Text);
                    temp.IdRubro = Convert.ToInt32(ddlRubro.SelectedValue);
                    bd.Articulos.InsertOnSubmit(temp);
                }
                else
                {
                    var temp = (from art in bd.Articulos
                                where art.IdArticulo == Convert.ToInt32(Request.QueryString["id"])
                                select art).Single();

                    temp.Denominacion = txtDenominacion.Text;
                    temp.Codigo = txtCodigo.Text;
                    temp.PrecioCompra = Convert.ToDouble(txtPrecioCompra.Text);
                    double iva = Convert.ToDouble(txtIVA.Text) / 100;
                    temp.Iva = iva;
                    temp.PrecioVenta = Convert.ToDouble(txtPrecioVenta.Text);
                    temp.IdRubro = Convert.ToInt32(ddlRubro.SelectedValue);
                }
                bd.SubmitChanges();
                Response.Redirect("Articulos.aspx");
            }
            catch (Exception) { }            
        }
    }
}