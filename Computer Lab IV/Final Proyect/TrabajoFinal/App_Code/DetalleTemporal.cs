 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class DetalleTemporal
{
    public int IdPedidoVentaDetalle { get; set; }
    public string Articulo { get; set; }
    public double PrecioUnitario { get; set; }
    public int Cantidad { get; set; }
    public double SubTotal { get; set; }
    public double Descuento { get; set; }
    public double Total { get; set; }
    public int IdPedidoVenta { get; set; }
    public int IdArticulo { get; set; }

    public DetalleTemporal() { }

}