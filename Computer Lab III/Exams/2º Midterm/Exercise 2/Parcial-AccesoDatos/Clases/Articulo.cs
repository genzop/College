using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial_AccesoDatos.Clases
{
    class Articulo
    {
        private int codigo;
        private string denominacion;
        private string rubro;
        private int stock;

        public int Codigo
        {
            get { return this.codigo; }
            set { this.codigo = value; }
        }

        public string Denominacion
        {
            get { return this.denominacion; }
            set { this.denominacion = value; }
        }

        public string Rubro
        {
            get { return this.rubro; }
            set { this.rubro = value; }
        }

        public int Stock
        {
            get { return this.stock; }
            set { this.stock = value; }
        }
    }
}
