using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoFinalApp.Modelo
{
    public class Domicilio
    {

        [PrimaryKey]
        public int IdDomicilio { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }
        public string Localidad { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }

        public Domicilio() { }
    }
}
