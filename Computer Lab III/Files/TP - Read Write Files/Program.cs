using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP___Read_Write_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            Gestor gestor = new Gestor();
            gestor.guardarArchivo("C:\\Users\\Enzo\\Desktop\\Customers.txt");
            gestor.leerArchivo("C:\\Users\\Enzo\\Desktop\\Customers.txt");
        }
    }
}
