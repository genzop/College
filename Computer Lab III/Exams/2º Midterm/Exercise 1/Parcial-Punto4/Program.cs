using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial_Punto4
{
    class Program
    {
        static void Main(string[] args)
        {
            Gestor gestor = new Gestor();
            gestor.leerArchivo(@"D:\Puesto 2.2\Escritorio\numeros.txt");
        }
    }
}
