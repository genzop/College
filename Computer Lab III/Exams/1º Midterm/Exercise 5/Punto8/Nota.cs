using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto8
{
    class Nota
    {

        private double valor;
        private Alumno alumno;

        public Nota()
        { }

        public Nota(double valor)
        {
            this.valor = valor;
        }

        public double Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        public Alumno Alumno
        {
            get { return alumno; }
            set { alumno = value; }
        }
    }
}
