using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoFinalApp.Modelo
{
    public class PedidoVentaDetalle
    {
        [PrimaryKey, AutoIncrement]
        public int IdPedidoVentaDetalle { get; set; }
        public int Cantidad { get; set; }
        public double SubTotal { get; set; }
        public double PorcentajeDescuento { get; set; }

        [ForeignKey(typeof(PedidoVenta))]
        public int IdPedidoVenta { get; set; }

        [ForeignKey(typeof(Articulo))]
        public int IdArticulo { get; set; }

        public PedidoVentaDetalle() { }        
     
         
    }
}
