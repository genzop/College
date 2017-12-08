using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Importar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var pedido = recibirPedido(Request["pedido"]);
        var detalles = recibirDetalles(Request["detalles"]);

        if(pedido != null && detalles != null)
        {
            BaseDatosDataContext bd = new BaseDatosDataContext();
            
            pedido.IdPedido = 0;

            bd.Pedidos.InsertOnSubmit(pedido);
            bd.SubmitChanges();

            foreach (Detalle detalle in detalles)
            {
                detalle.IdDetalle = 0;
                detalle.IdPedido = pedido.IdPedido;
                detalle.Descuento = detalle.Descuento / 100;

                bd.Detalles.InsertOnSubmit(detalle);
                bd.SubmitChanges();
            }

            calcularSaldoCliente(Convert.ToInt32(pedido.IdCliente));
        }
      
    }

    private Pedido recibirPedido(string pedidoJSON)
    {
        if (!string.IsNullOrEmpty(pedidoJSON))
        {
            // Se elimina la propiedad cliente del pedido                  
            JObject pedidoTemp = JObject.Parse(pedidoJSON);
            pedidoTemp.Property("Cliente").Remove();
            pedidoJSON = pedidoTemp.ToString();

            //Se crea un pedido con la informacion recibida
            Pedido pedido = JsonConvert.DeserializeObject<Pedido>(pedidoJSON);
            return pedido;
        }
        else
        {
            return null;
        }
    }

    private List<Detalle> recibirDetalles(string detallesJSON)
    {
        if (!string.IsNullOrEmpty(detallesJSON))
        {
            //Se elimina la propiedad Articulo y PrecioUnitario de cada detalle
            JArray detallesTemp = JArray.Parse(detallesJSON);
            foreach (JObject det in detallesTemp.Children<JObject>())
            {
                det.Property("Articulo").Remove();
                det.Property("PrecioUnitario").Remove();
            }
            detallesJSON = detallesTemp.ToString();

            //Se crea una lista de detalles
            List<Detalle> detalles = JsonConvert.DeserializeObject<List<Detalle>>(detallesJSON);
            return detalles;
        }
        else
        {
            return null;
        }
    }

    private void calcularSaldoCliente(int idCliente)
    {
        BaseDatosDataContext bd = new BaseDatosDataContext();

        double subtotalCliente = 0;

        //Se verifica si ese cliente tiene pedidos a su nombre
        bool tienePedidos = (from ped in bd.Pedidos
                             where ped.IdCliente == idCliente
                             select ped).Any();

        //Si tiene pedidos 
        if (tienePedidos)
        {
            //Se cargan los pedidos
            var pedidos = from ped in bd.Pedidos
                          where ped.IdCliente == idCliente
                          select ped;

            foreach (var pedido in pedidos)
            {
                //Sino esta pagado el pedido
                if (!Convert.ToBoolean(pedido.Pagado))
                {
                    //Se suma el monto total de cada pedido
                    subtotalCliente += Convert.ToDouble(pedido.Total);
                }                
            }
        }

        var cliente = (from cli in bd.Clientes
                       where cli.IdCliente == idCliente
                       select cli).Single();

        cliente.Saldo = 0 + subtotalCliente;
        bd.SubmitChanges();
    }
}