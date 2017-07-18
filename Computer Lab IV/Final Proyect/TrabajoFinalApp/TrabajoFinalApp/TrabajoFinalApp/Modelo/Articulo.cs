using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoFinalApp.Modelo
{
    public class Articulo
    {
        [PrimaryKey]
        public int IdArticulo { get; set; }
        public string Denominacion { get; set; }
        public string Codigo { get; set; }
        public double PrecioCompra { get; set; }
        public double PrecioVenta { get; set; }
        public double Iva { get; set; }      
        public double IdRubro { get; set; }  

        public Articulo() { }

        public Articulo(int id, string denominacion, string codigo, double precioCompra, double precioVenta, double iva)
        {
            this.IdArticulo = id;
            this.Denominacion = denominacion;
            this.Codigo = codigo;
            this.PrecioCompra = precioCompra;
            this.PrecioVenta = precioVenta;
            this.Iva = iva;
        }

    }
}
