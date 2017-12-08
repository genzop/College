using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ArticuloCantidad
/// </summary>
public class ArticuloCantidad
{
    public string Denominacion { get; set; }
    public int Cantidad { get; set; }
    public double Precio { get; set; }
    public string Rubro { get; set; }
    public double Descuento { get; set; }
    public double Total { get; set; }

    public ArticuloCantidad()
    {

    }

    public ArticuloCantidad(string denominacion, int cantidad, double precio, string rubro, double subtotal)
    {
        this.Denominacion = denominacion;
        this.Cantidad = cantidad;
        this.Precio = precio;
        this.Rubro = rubro;
        this.Total = subtotal;
    }
}