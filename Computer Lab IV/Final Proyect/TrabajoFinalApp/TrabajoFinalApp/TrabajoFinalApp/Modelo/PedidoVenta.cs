using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoFinalApp.Modelo
{
    public class PedidoVenta
    {
        [PrimaryKey]
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

        [ForeignKey(typeof(Domicilio))]
        public int IdDomicilio { get; set; }

        [ForeignKey(typeof(Cliente))]
        public int IdCliente { get; set; }

        [ForeignKey(typeof(Vendedor))]
        public int IdVendedor { get; set; }


        public PedidoVenta() { }
                


        //ARREGLAR!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public string Cliente { get; set; }

    }
}
