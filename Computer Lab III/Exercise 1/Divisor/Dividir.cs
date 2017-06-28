using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divisor
{
    class Dividir
    {
        static void Main(string[] args)
        {
            try {
                Console.WriteLine("Ingrese el primer numero:");
                string temp = Console.ReadLine();
                int i = Int32.Parse(temp);
                Console.WriteLine("Ingrese el segundo numero:");
                temp = Console.ReadLine();
                int j = Int32.Parse(temp);
                int k = i / j;
                Console.WriteLine("El resultado de dividir {0} por {1} es igual a {2}", i, j, k);
            } catch (Exception e) {
                Console.WriteLine("Excepcion lanzada: {0}" , e);
            }           
        }
    }
}
