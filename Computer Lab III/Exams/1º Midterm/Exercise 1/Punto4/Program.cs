using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto4
{
    class Program
    {
        static void Main(string[] args)
        {
            Gestor gestor = new Gestor();
            string cadenaSinLetras = gestor.eliminarLetras("dfdf2-1df5-0los45g");
            Console.WriteLine(cadenaSinLetras);
        }
    }
}
