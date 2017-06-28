using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPAccesoDatos.Clases
{
    class Author
    {

        private string id;
        private string apellido;
        private string nombre;
        private string telefono;
        private string direccion;
        private string ciudad;
        private string provincia;
        private string codigoPostal;
        private string contrato;

        public string Id {
            get { return id; }
            set { id = value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
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

        public string CodigoPostal
        {
            get { return codigoPostal; }
            set { codigoPostal = value; }
        }

        public string Contrato
        {
            get { return contrato; }
            set { contrato = value; }
        }
    }
}
