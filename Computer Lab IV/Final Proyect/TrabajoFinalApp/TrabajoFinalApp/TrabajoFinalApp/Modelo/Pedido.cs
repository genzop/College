using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoFinalApp.Modelo
{
    public class Pedido
    {
        [PrimaryKey]
        public int IdPedido { get; set; }
        public bool Editable { get; set; }
        public string Estado { get; set; }
        public bool Pagado { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime FechaEntrega { get; set; }
        public double Subtotal { get; set; }
        public double GastosEnvio { get; set; }
        public double Total { get; set; }
        [ForeignKey(typeof(Cliente))]
        public int IdCliente { get; set; }
        [ForeignKey(typeof(Vendedor))]
        public int IdVendedor { get; set; }

        //Agregado para que se vea en la lista
        public string Cliente { get; set; }

        public Pedido() { }
    }
}
