using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoFinalApp.Modelo
{
    public class Vendedor
    {
        [PrimaryKey]
        public int IdVendedor { get; set; }
        public string Usuario { get; set; }
        public string Contrasenia { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public bool Administrador { get; set; }

        public Vendedor() { }

        public Vendedor(int id, string usuario, string contrasenia, string nombre, string apellido)
        {
            this.IdVendedor = id;
            this.Usuario = usuario;
            this.Contrasenia = contrasenia;
            this.Nombre = nombre;
            this.Apellido = apellido;
        }
    }
}
