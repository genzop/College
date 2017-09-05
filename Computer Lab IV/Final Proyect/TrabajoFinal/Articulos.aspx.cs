using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Articulos : System.Web.UI.Page
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
            HyperLink articulos = (HyperLink)Master.FindControl("hlArticulos");
            articulos.CssClass = "active";

            if (Convert.ToInt32(Session["IdVendedor"]) != 20)
            {
                grdArticulos.Columns[6].Visible = false;
                grdArticulos.Columns[7].Visible = false;
                hlAdd.Visible = false;
            }
        }
    }

    protected void imgEdit_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("EditarArticulo.aspx?id=" + e.CommandArgument);
    }

    protected void imgDelete_Command(object sender, CommandEventArgs e)
    {
        try
        {
            string idSeleccionado = e.CommandArgument.ToString();

            var esUsado = (from det in bd.PedidoVentaDetalles
                           where det.IdArticulo == Convert.ToInt32(idSeleccionado)
                           select det).Any();

            if (esUsado)
            {
                Response.Write("<script language=\"JavaScript\">alert(\"El artículo no puede ser eliminado ya que esta asociado con algun pedido\")</script>");
            }
            else
            {
                var temp = (from art in bd.Articulos
                            where art.IdArticulo == Convert.ToInt32(idSeleccionado)
                            select art).Single();

                bd.Articulos.DeleteOnSubmit(temp);
                bd.SubmitChanges();
                grdArticulos.DataBind();
            }
        }
        catch (Exception) { }                
    }

    protected void txtBuscar_TextChanged(object sender, EventArgs e)
    {
        string query = "SELECT Articulo.IdArticulo, Articulo.Denominacion, Articulo.Codigo, Articulo.PrecioCompra, Articulo.PrecioVenta, " +
                       "Articulo.Iva, Rubro.Denominacion FROM Articulo INNER JOIN Rubro ON Articulo.IdRubro = Rubro.IdRubro " +
                       "WHERE " + ddlBuscar.SelectedValue + " LIKE '%" + txtBuscar.Text + "%'";

        SqlDataSource1.SelectCommand = query;
        grdArticulos.DataBind();
    }
}