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

        public Cliente() { }

        public Cliente(int id, string razonSocial, string cuit, double saldo)
        {
            this.IdCliente = id;
            this.RazonSocial = razonSocial;
            this.Cuit = cuit;
            this.Saldo = saldo;
        }

    }
}
