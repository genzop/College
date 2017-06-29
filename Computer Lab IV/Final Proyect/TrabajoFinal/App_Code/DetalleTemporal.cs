using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class DetalleTemporal
{
    private int IdPedidoVentaDetalle { get; set; }
    private string Articulo { get; set; }
    private double PrecioUnitario { get; set; }
    private int Cantidad { get; set; }    
    private double Descuento { get; set; }
    private double SubTotal { get; set; }
    private int IdPedidoVenta { get; set; }
    private int IdArticulo { get; set; }

    public DetalleTemporal() { }
    public DetalleTemporal(int idPedidoVentaDetalle, string articulo, double precioUnitario, int cantidad, double descuento, double subTotal, int idPedidoVenta, int idArticulo)
    {
        this.IdPedidoVentaDetalle = idPedidoVentaDetalle;
        this.Articulo = articulo;
        this.PrecioUnitario = precioUnitario;
        this.Cantidad = cantidad;
        this.Descuento = descuento;
        this.SubTotal = subTotal;
        this.IdPedidoVenta = idPedidoVenta;
        this.IdArticulo = idArticulo;
    }
}