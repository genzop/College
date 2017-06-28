using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto8
{
    class Alumno
    {
        private string nombre;
        private List<Nota> notas;

        public Alumno()
        {
            this.notas = new List<Nota>();
        }

        public Alumno(string nombre)
        {
            this.nombre = nombre;
            this.notas = new List<Nota>();
        }


        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public List<Nota> Notas
        {
            get { return notas; }
            set { notas = value; }
        }

        public double promedioNota()
        {
            int cantNotas = Notas.Count;
            double notaPromedio = 0;
            foreach (Nota n in Notas)
            {
                notaPromedio += n.Valor;
            }
            return notaPromedio / cantNotas;
        }

        public Nota mejorNota()
        {
            Nota mejorNota = new Nota(0);
            foreach (Nota n in Notas)
            {
                if (n.Valor > mejorNota.Valor)
                {
                    mejorNota = n;
                }
            }
            return mejorNota;
        }

    }
}
