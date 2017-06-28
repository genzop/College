using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto8
{
    class Program
    {
        static void Main(string[] args)
        {
            Alumno alumno = new Alumno("Fernando");
            Nota nota1 = new Nota(7);
            Nota nota2 = new Nota(10);
            Nota nota3 = new Nota(6);

            nota1.Alumno = alumno;
            nota2.Alumno = alumno;
            nota3.Alumno = alumno;

            alumno.Notas.Add(nota1);
            alumno.Notas.Add(nota2);
            alumno.Notas.Add(nota3);

            Console.WriteLine("El promedio de las notas es: " + alumno.promedioNota());

            Nota notaMaxima = alumno.mejorNota();


        }
    }
}
