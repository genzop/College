using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pedidos : System.Web.UI.Page
{
    BaseDatosDataContext bd = new BaseDatosDataContext();
    Vendedor usuario = null;

    
    protected void Page_Load(object sender, EventArgs e)
    {
        //Si no hay una sesion iniciada se redirecciona a la pagina de LogIn
        if (Session["IdVendedor"] == null)
        {
            Response.Redirect("Ingresar.aspx");
        }
        else
        {           
            HyperLink pedidos = (HyperLink)Master.FindControl("hlPedidos");
            pedidos.CssClass = "active";
            
            usuario = (from vend in bd.Vendedors
                       where vend.IdVendedor == Convert.ToInt32(Session["IdVendedor"])
                       select vend).FirstOrDefault();

            //Si el usuario es administrador, se muestran cargan todos los pedidos en la tabla
            if (usuario.Administrador)
            {
                SqlDataSource1.SelectCommand = "SELECT Pedido.IdPedido, Pedido.Editable, Pedido.Pagado, Pedido.FechaEntrega, Pedido.GastosEnvio, Pedido.Estado, Pedido.FechaPedido, Pedido.SubTotal, Pedido.Total, Cliente.RazonSocial, Vendedor.Nombre + ' ' + Vendedor.Apellido AS Vendedor FROM Pedido INNER JOIN Cliente ON Pedido.IdCliente = Cliente.IdCliente INNER JOIN Vendedor ON Pedido.IdVendedor = Vendedor.IdVendedor";                                    
            }
        }
    }
    
    //Redirecciona a la pagina EditarPedido
    protected void imgEdit_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("EditarPedido.aspx?id=" + e.CommandArgument);
    }

    //Elimina el Pedido seleccionado
    protected void imgDelete_Command(object sender, CommandEventArgs e)
    {
        try
        {
            int registroSeleccionado = Convert.ToInt32(e.CommandArgument);

            //Se eliminan todos los detalles asociados con este pedido
            var detalles = from detalle in bd.Detalles
                           where detalle.IdPedido == registroSeleccionado
                           select detalle;
            foreach (var detalle in detalles)
            {
                bd.Detalles.DeleteOnSubmit(detalle);
                bd.SubmitChanges();
            }

            //Se elimina el pedido
            var temp = (from pedido in bd.Pedidos
                        where pedido.IdPedido == Convert.ToInt32(registroSeleccionado)
                        select pedido).Single();          

            int idCliente = Convert.ToInt32(temp.IdCliente);
            bd.Pedidos.DeleteOnSubmit(temp);            
            bd.SubmitChanges();

            calcularSaldoCliente(idCliente);
            imgFind_Click(null, null);
        }
        catch (Exception) { }
    }

    //Calcula el saldo total del cliente
    private void calcularSaldoCliente(int idCliente)
    {
        try
        {
            double saldo = 0;

            //Verifica si el cliente tiene Pedidos asociados
            bool hayPedidos = (from ped in bd.Pedidos
                               where ped.IdCliente == idCliente
                               select ped).Any();
                        
            if (hayPedidos)
            {
                var pedidos = from ped in bd.Pedidos
                              where ped.IdCliente == idCliente
                              select ped;

                foreach (var pedido in pedidos)
                {
                    if (!pedido.Pagado)
                    {
                        saldo += Convert.ToDouble(pedido.Total);
                    }                    
                }
            }

            Cliente cliente = (from cli in bd.Clientes
                               where cli.IdCliente == idCliente
                               select cli).Single();

            cliente.Saldo = saldo;
            bd.SubmitChanges();
        }
        catch (Exception) { }       
    }

    //Se busca los pedidos que cumplan con el criterio indicado
    protected void imgFind_Click(object sender, ImageClickEventArgs e)
    {
        string query = "";

        if (usuario.Administrador)
        {
            if (txtBuscar.Text == "")
            {
                query = "SELECT Pedido.IdPedido, Pedido.Editable, Pedido.Pagado, Pedido.FechaEntrega, Pedido.GastosEnvio, Pedido.Estado, Pedido.FechaPedido, Pedido.SubTotal, Pedido.Total, Cliente.RazonSocial FROM Pedido INNER JOIN Cliente ON Pedido.IdCliente = Cliente.IdCliente";                       
            }
            else
            {
                query = "SELECT Pedido.IdPedido, Pedido.Editable, Pedido.Pagado, Pedido.FechaEntrega, Pedido.GastosEnvio, Pedido.Estado, Pedido.FechaPedido, Pedido.SubTotal, Pedido.Total, Cliente.RazonSocial FROM Pedido INNER JOIN Cliente ON Pedido.IdCliente = Cliente.IdCliente WHERE " + ddlBuscar.SelectedValue + " LIKE '%" + txtBuscar.Text + "%'";                       
            }
        }
        else
        {
            if (txtBuscar.Text == "")
            {
                query = "SELECT Pedido.IdPedido, Pedido.Editable, Pedido.Pagado, Pedido.FechaEntrega, Pedido.GastosEnvio, Pedido.Estado, Pedido.FechaPedido, Pedido.SubTotal, Pedido.Total, Cliente.RazonSocial FROM Pedido INNER JOIN Cliente ON Pedido.IdCliente = Cliente.IdCliente WHERE Pedido.IdVendedor = @vendedor";                       
            }
            else
            {
                query = "SELECT Pedido.IdPedido, Pedido.Editable, Pedido.Pagado, Pedido.FechaEntrega, Pedido.GastosEnvio, Pedido.Estado, Pedido.FechaPedido, Pedido.SubTotal, Pedido.Total, Cliente.RazonSocial FROM Pedido INNER JOIN Cliente ON Pedido.IdCliente = Cliente.IdCliente WHERE Pedido.IdVendedor=@vendedor AND " + ddlBuscar.SelectedValue + " LIKE '%" + txtBuscar.Text + "%'";                       
            }
        }

        SqlDataSource1.SelectCommand = query;
        grdPedidos.DataBind();
    }

    protected void imgAdd_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("EditarPedido.aspx");
    }    
}