using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
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
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        [ForeignKey(typeof(Localidad))]
        public int IdLocalidad { get; set; }

        public Domicilio() { }

        public Domicilio(int id, string calle, int numero)
        {
            this.IdDomicilio = id;
            this.Calle = calle;
            this.Numero = numero;
        }

    }
}
