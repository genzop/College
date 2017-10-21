using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoFinalApp.Modelo
{
    public class Pais
    {
        [PrimaryKey]
        public int IdPais { get; set; }
        public string Denominacion { get; set; }

        public Pais() { }
    }
}
