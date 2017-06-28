using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numeros = new int[10];
            Gestor gestor = new Gestor();

            numeros = gestor.cargarNumeros();
            int suma = gestor.sumaRecursiva(numeros, 0);
            Console.WriteLine("La suma de todos los valores del arreglo es: " + suma);            
        }
    }
}
