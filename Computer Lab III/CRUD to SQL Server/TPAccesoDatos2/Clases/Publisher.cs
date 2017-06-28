using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPAccesoDatos2.Clases
{
    class Publisher
    {

        private string id;
        private string nombre;
        private string ciudad;
        private string provincia;
        private string pais;

        public Publisher() { }
        
        public Publisher(string id, string nombre, string ciudad, string provincia, string pais)
        {
            this.id = id;
            this.nombre = nombre;
            this.ciudad = ciudad;
            this.provincia = provincia;
            this.pais = pais;
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Ciudad
        {
            get { return ciudad; }
            set { ciudad = value; }
        }

        public string Provincia
        {
            get { return provincia; }
            set { provincia = value; }
        }

        public string Pais
        {
            get { return pais; }
            set { pais = value; }
        }

    }
}
