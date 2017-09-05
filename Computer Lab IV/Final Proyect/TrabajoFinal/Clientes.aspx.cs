using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Clientes : System.Web.UI.Page
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
            HyperLink clientes = (HyperLink)Master.FindControl("hlClientes");
            clientes.CssClass = "active";

            if (Convert.ToInt32(Session["IdVendedor"]) != 20)
            {                
                grdClientes.Columns[6].Visible = false;
                grdClientes.Columns[7].Visible = false;
                hlAdd.Visible = false;                         
            }            
        }        
    }

    protected void imgEdit_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("EditarCliente.aspx?id=" + e.CommandArgument);
    }

    protected void imgDelete_Command(object sender, CommandEventArgs e)
    {
        try
        {
            string idSeleccionado = e.CommandArgument.ToString();

            bool tienePedidos = (from ped in bd.PedidoVentas
                                 where ped.IdCliente == Convert.ToInt32(idSeleccionado)
                                 select ped).Any();

            if (tienePedidos)
            {
                Response.Write("<script language=\"JavaScript\">alert(\"El cliente no puede ser eliminado ya que tiene pedidos asociados a su cuenta\")</script>");
            }
            else
            {
                var temp = (from cli in bd.Clientes
                            where cli.IdCliente == Convert.ToInt32(idSeleccionado)
                            select cli).Single();
                var tempDom = (from dom in bd.Domicilios
                               where dom.IdDomicilio == temp.IdDomicilio
                               select dom).Single();

                bd.Clientes.DeleteOnSubmit(temp);
                bd.Domicilios.DeleteOnSubmit(tempDom);
                bd.SubmitChanges();
                grdClientes.DataBind();
            }
        }
        catch (Exception) { }       
    }

    protected void txtBuscar_TextChanged(object sender, EventArgs e)
    {
        string query = "SELECT Cliente.IdCliente, Cliente.RazonSocial, Cliente.Cuit, Cliente.Saldo, Domicilio.Calle, Domicilio.Numero, " +
                       "Domicilio.Localidad FROM Cliente INNER JOIN Domicilio ON Cliente.IdDomicilio = Domicilio.IdDomicilio " +
                       "WHERE " + ddlBuscar.SelectedValue + " LIKE '%" + txtBuscar.Text + "%'";

        SqlDataSource1.SelectCommand = query;
        grdClientes.DataBind();
    }
}