using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoFinalApp.Modelo
{
    public class PedidoVentaDetalleTabla
    {

        public int IdPedidoVentaDetalle { get; set; }
        public int Cantidad { get; set; }
        public double SubTotal { get; set; }
        public double PorcentajeDescuento { get; set; }
        public int IdPedidoVenta { get; set; }
        public int IdArticulo { get; set; }
        public string Articulo { get; set; }
        public double PrecioUnitario { get; set; }

        public PedidoVentaDetalleTabla() { }

        public PedidoVentaDetalleTabla(int cantidad, string articulo, double precio, double descuento, double subTotal)
        {
            this.Cantidad = cantidad;
            this.SubTotal = subTotal;
            this.PorcentajeDescuento = descuento;
            this.Articulo = articulo;
            this.PrecioUnitario = precio;
        }

    }
}
