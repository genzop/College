using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2___Parte_C___Ej1 {
    class Program {
        static void Main(string[] args) {
            string[] auxNumeros = new string[10];
            int[] numeros = new int[10];
            int resultado = 0;

            Console.WriteLine("Ingresar 10 numeros enteros: ");
            for (int i = 0; i < auxNumeros.Length; i++) {
                auxNumeros[i] = Console.ReadLine();
                numeros[i] = Int32.Parse(auxNumeros[i]);
            }

            foreach (int num in numeros) {
                resultado += num;
            }

            Console.WriteLine("Resultado: {0}", resultado);
        }
    }
}
