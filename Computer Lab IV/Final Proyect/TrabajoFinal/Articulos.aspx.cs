using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Articulos : System.Web.UI.Page
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
            HyperLink articulos = (HyperLink)Master.FindControl("hlArticulos");
            articulos.CssClass = "active";

            var usuario = (from vend in bd.Vendedors
                           where vend.IdVendedor == Convert.ToInt32(Session["IdVendedor"])
                           select vend).FirstOrDefault();

            if (!usuario.Administrador)
            {
                grdArticulos.Columns[6].Visible = false;
                grdArticulos.Columns[7].Visible = false;
                imgAdd.Visible = false;
            }
        }
    }

    protected void imgAdd_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("EditarArticulo.aspx");
    }

    protected void imgEdit_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("EditarArticulo.aspx?id=" + e.CommandArgument);
    }

    protected void imgDelete_Command(object sender, CommandEventArgs e)
    {
        try
        {
            int idSeleccionado = Convert.ToInt32(e.CommandArgument.ToString().ToString());

            var estaEnUso = (from det in bd.Detalles
                             where det.IdArticulo == idSeleccionado
                             select det).Any();

            if (estaEnUso)
            {                
                ScriptManager.RegisterClientScriptBlock(updatePanel, GetType(), "errorEliminarArticulo", "alert('El artículo no puede ser eliminado ya que esta asociado con algun pedido')", true);
            }
            else
            {
                var temp = (from art in bd.Articulos
                            where art.IdArticulo == idSeleccionado
                            select art).Single();

                bd.Articulos.DeleteOnSubmit(temp);
                bd.SubmitChanges();
                grdArticulos.DataBind();
            }
        }
        catch (Exception) { }                
    }

    protected void imgFind_Click(object sender, ImageClickEventArgs e)
    {
        string query = "";

        if (txtBuscar.Text == "")
        {
            query = "SELECT Articulo.IdArticulo, Articulo.Denominacion, Articulo.PrecioCompra, Articulo.PrecioVenta, Rubro.Denominacion FROM Articulo INNER JOIN Rubro ON Articulo.IdRubro = Rubro.IdRubro";
        }
        else
        {
            query = "SELECT Articulo.IdArticulo, Articulo.Denominacion, Articulo.PrecioCompra, Articulo.PrecioVenta, Rubro.Denominacion FROM Articulo INNER JOIN Rubro ON Articulo.IdRubro = Rubro.IdRubro WHERE " + ddlBuscar.SelectedValue + " LIKE '%" + txtBuscar.Text + "%'";
        }
        SqlDataSource1.SelectCommand = query;
        grdArticulos.DataBind();
    }       
}