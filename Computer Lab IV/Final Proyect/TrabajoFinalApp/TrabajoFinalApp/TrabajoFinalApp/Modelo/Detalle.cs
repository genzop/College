using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoFinalApp.Modelo
{
    public class Detalle
    {
        [PrimaryKey, AutoIncrement]
        public int IdDetalle { get; set; }
        public int Cantidad { get; set; }
        public double Subtotal { get; set; }
        public double Descuento { get; set; }
        public double Total { get; set; }
        [ForeignKey(typeof(Pedido))]
        public int IdPedido { get; set; }
        [ForeignKey(typeof(Articulo))]
        public int IdArticulo { get; set; }

        //Agregado para que se vea en la lista
        public string Articulo { get; set; }
        public double PrecioUnitario { get; set; }
    }
}
