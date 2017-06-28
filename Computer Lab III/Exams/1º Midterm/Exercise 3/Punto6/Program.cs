using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto6
{
    class Program
    {
        static void Main(string[] args)
        {
            Gestor gestor = new Gestor();
            int[] pares = { 2, 4, 6, 8, 10 };
            int[] impares = { 1, 3, 5, 7, 9 };

            int[] numeros = gestor.unirMatrices(pares,impares);

            foreach (int num in numeros)
            {
                Console.WriteLine(num);
            }
        }
    }
}
