using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoFinalApp.Modelo
{
    public class PedidoVenta
    {
        public int IdPedidoVenta { get; set; }
        public long NroPedido { get; set; }
        public string Estado { get; set; }
        public bool Entregado { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime FechaEstimadaEntrega { get; set; }
        public double SubTotal { get; set; }
        public double GastosEnvio { get; set; }        
        public double MontoTotal { get; set; }
        public bool EsEditable { get; set; }
        public int IdDomicilio { get; set; }
        public int IdCliente { get; set; }
        public int IdVendedor { get; set; }

        public PedidoVenta() { }



        public string Cliente { get; set; }

    }
}
