using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2___Parte_B___Ej4 {
    class Overloading {
        static int Sumar(int a, int b) {
            return a + b;
        }
        
        static string Sumar(string cadena1, string cadena2) {
            return cadena1 + " " + cadena2;
        }
        
        public static void Main() {
            Console.WriteLine(Sumar(1, 2));            
            Console.WriteLine(Sumar("HOLA", "MUNDO"));
        }
    }
}
