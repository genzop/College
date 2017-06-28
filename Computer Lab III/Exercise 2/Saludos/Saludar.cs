using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saludos
{
    class Saludar
    {
        static void Main(string[] args){
            String miNombre;
            Console.WriteLine("Ingrese su nombre:");
            miNombre = Console.ReadLine( );
            Console.WriteLine("Hola, {0}", miNombre);            
        }
    }
}
