using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoFinalApp.Modelo
{
    public class Cliente
    {
        [PrimaryKey]
        public int IdCliente { get; set; }
        public string RazonSocial { get; set; }
        public string Cuit { get; set; }
        public double Saldo { get; set; }

        [ForeignKey(typeof(Domicilio))]
        public int IdDomicilio { get; set; }

        public Cliente() { }

    }
}
