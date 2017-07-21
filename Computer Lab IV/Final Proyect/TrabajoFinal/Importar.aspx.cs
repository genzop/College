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
        var domicilio = recibirDomicilio(Request["domicilio"]);
        var pedido = recibirPedido(Request["pedido"]);
        var detalles = recibirDetalles(Request["detalles"]);

        if(domicilio != null || pedido != null || detalles != null)
        {
            BaseDatosDataContext bd = new BaseDatosDataContext();
            domicilio.IdDomicilio = 0;

            bd.Domicilios.InsertOnSubmit(domicilio);
            bd.SubmitChanges();
                        
            pedido.IdPedidoVenta = 0;
            pedido.IdDomicilio = domicilio.IdDomicilio;

            bd.PedidoVentas.InsertOnSubmit(pedido);
            bd.SubmitChanges();

            foreach (PedidoVentaDetalle detalle in detalles)
            {
                detalle.IdPedidoVentaDetalle = 0;
                detalle.IdPedidoVenta = pedido.IdPedidoVenta;
                detalle.PorcentajeDescuento = detalle.PorcentajeDescuento / 100;

                bd.PedidoVentaDetalles.InsertOnSubmit(detalle);
                bd.SubmitChanges();
            }

            calcularSaldoCliente(Convert.ToInt32(pedido.IdCliente));
        }
      
    }

    private Domicilio recibirDomicilio(string domicilioJSON)
    {
        if (!string.IsNullOrEmpty(domicilioJSON))
        {
            //Se crea un domicilio con la informacion recibida
            Domicilio domicilio = JsonConvert.DeserializeObject<Domicilio>(domicilioJSON);
            return domicilio;
        }
        else
        {
            return null;
        }
    }

    private PedidoVenta recibirPedido(string pedidoJSON)
    {
        if (!string.IsNullOrEmpty(pedidoJSON))
        {
            // Se elimina la propiedad cliente del pedido                  
            JObject pedidoTemp = JObject.Parse(pedidoJSON);
            pedidoTemp.Property("Cliente").Remove();
            pedidoJSON = pedidoTemp.ToString();

            //Se crea un pedido con la informacion recibida
            PedidoVenta pedido = JsonConvert.DeserializeObject<PedidoVenta>(pedidoJSON);
            return pedido;
        }
        else
        {
            return null;
        }
    }

    private List<PedidoVentaDetalle> recibirDetalles(string detallesJSON)
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
            List<PedidoVentaDetalle> detalles = JsonConvert.DeserializeObject<List<PedidoVentaDetalle>>(detallesJSON);
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
        bool tienePedidos = (from ped in bd.PedidoVentas
                             where ped.IdCliente == idCliente
                             select ped).Any();

        //Si tiene pedidos 
        if (tienePedidos)
        {
            //Se cargan los pedidos
            var pedidos = from ped in bd.PedidoVentas
                          where ped.IdCliente == idCliente
                          select ped;

            foreach (var pedido in pedidos)
            {
                //Se suma el monto total de cada pedido
                subtotalCliente += Convert.ToDouble(pedido.MontoTotal);
            }
        }

        var cliente = (from cli in bd.Clientes
                       where cli.IdCliente == idCliente
                       select cli).Single();

        cliente.Saldo = 0 - subtotalCliente;
        bd.SubmitChanges();
    }
}