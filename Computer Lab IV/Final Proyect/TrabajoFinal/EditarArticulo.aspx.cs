using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditarArticulo : System.Web.UI.Page
{
    BaseDatosDataContext bd = new BaseDatosDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdVendedor"] == null)
        {
            Response.Redirect("Ingresar.aspx");
        }
        else
        {
            if (Request.QueryString["id"] != null)
            {
                lblTitulo.Text = "Editar Artículo";

                try
                {
                    var temp = (from art in bd.Articulos
                                where art.IdArticulo == Convert.ToInt32(Request.QueryString["id"])
                                select art).FirstOrDefault();

                    if (!IsPostBack)
                    {
                        txtCodigo.Text = temp.IdArticulo.ToString();
                        txtDenominacion.Text = temp.Denominacion;                        
                        txtPrecioCompra.Text = temp.PrecioCompra.ToString();                        
                        txtPrecioVenta.Text = temp.PrecioVenta.ToString();
                        ddlRubro.SelectedValue = temp.IdRubro.ToString();
                    }
                }
                catch (Exception) { }               
            }
            else
            {
                var ultimoID = (from num in bd.GetIdentityArticulo()
                                select num.Column1).FirstOrDefault();

                txtCodigo.Text = (Convert.ToInt32(ultimoID) + 1).ToString();
            }
        }
    }

    protected void btnAccion_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                if (Request.QueryString["id"] == null)
                {
                    Articulo temp = new Articulo();
                    temp.Denominacion = txtDenominacion.Text;                    
                    temp.PrecioCompra = Convert.ToDouble(txtPrecioCompra.Text);                    
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
                    temp.PrecioCompra = Convert.ToDouble(txtPrecioCompra.Text);
                    temp.PrecioVenta = Convert.ToDouble(txtPrecioVenta.Text);
                    temp.IdRubro = Convert.ToInt32(ddlRubro.SelectedValue);
                }
                bd.SubmitChanges();
                Response.Redirect("Articulos.aspx");
            }
            catch (Exception) { }            
        }
    }

    protected void cvArticuloUnico_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (Request.QueryString["id"] == null)
        {
            var articulo = (from art in bd.Articulos
                            where art.Denominacion == txtDenominacion.Text
                            select art).FirstOrDefault();

            if (articulo == null)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }
        else
        {
            var articulo = (from art in bd.Articulos
                            where art.Denominacion == txtDenominacion.Text && art.IdArticulo != Convert.ToInt32(txtCodigo.Text)
                            select art).FirstOrDefault();

            if (articulo == null)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }
    }
}