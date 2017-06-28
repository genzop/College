using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2___Parte_A___Ej3 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Ingresar cuantos numeros enteros se quieren sumar:");
            string auxCantNum = Console.ReadLine();
            int cantNum = Int32.Parse(auxCantNum);

            Console.WriteLine("Ingresar los numeros:");
            string[] auxNumeros = new string[cantNum];
            for (int i = 0; i < cantNum; i++) {
                auxNumeros[i] = Console.ReadLine();
            }

            int resultado = 0;
            try {
                foreach (string palabra in auxNumeros) {
                    try {
                        resultado += convertirAEntero(palabra);
                    } catch (NumeroNoEnteroException nnee) {
                        Console.WriteLine("Error: {0} {1}", palabra, nnee.Message);
                    }
                }
            } finally {
                Console.WriteLine("Resultado: {0}", resultado);
                Console.WriteLine("FIN DEL PROGRAMA");
            }
        }

        public static int convertirAEntero(string palabra) {
            int numAux;
            if (Int32.TryParse(palabra, out numAux)) {
                numAux = Int32.Parse(palabra);
                return numAux;
            } else {
                throw new NumeroNoEnteroException();
            }
        }
    }
}
