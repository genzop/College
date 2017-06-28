using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2___Parte_C___Ej2 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Ingresar la cantidad de filas:");
            string aux = Console.ReadLine();
            int cantFilas = int.Parse(aux);

            Console.WriteLine("Ingresar la cantidad de columnas:");
            aux = Console.ReadLine();
            int cantColumnas = int.Parse(aux);           

            int[,] matriz = new int[cantFilas, cantColumnas];

            for (int i = 0; i < matriz.GetLength(0); i++) {
                for (int j = 0; j < matriz.GetLength(1); j++) {
                    matriz[i,j] = i + j;
                }
            }

            Console.WriteLine("\nMatriz resultante:");

            for (int i = 0; i < matriz.GetLength(0); i++) {
                for (int j = 0; j < matriz.GetLength(1); j++) {
                    Console.Write(matriz[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
