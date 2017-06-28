using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2___Parte_A___Ej1 {
    class DividePorCero {
        static void Main(string[] args) {
            try {
                Console.WriteLine("Ingrese el primer numero entero:");
                string temp = Console.ReadLine();
                int num1 = Int32.Parse(temp);

                Console.WriteLine("Ingrese el segundo numero entero:");
                temp = Console.ReadLine();
                int num2 = Int32.Parse(temp);

                double resultado = num1 / num2;

                Console.WriteLine("El resultado de dividir {0} por {1} es {2}", num1, num2, resultado);
            } catch (DivideByZeroException e) {
                Console.WriteLine("Error: division por cero");
            }
        }
    }
}
