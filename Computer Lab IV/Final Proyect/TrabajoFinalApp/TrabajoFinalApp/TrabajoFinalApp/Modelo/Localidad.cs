using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoFinalApp.Modelo
{
    public class Localidad
    {
        [PrimaryKey]
        public int IdLocalidad { get; set; }
        public string Denominacion { get; set; }
        [ForeignKey(typeof(Provincia))]
        public int IdProvincia { get; set; }

        public Localidad() { }
    }
}
