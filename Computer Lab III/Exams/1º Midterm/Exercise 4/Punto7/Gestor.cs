using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto7
{
    class Gestor
    {
        public void matrizInversa()
        {
            Console.WriteLine("Ingrese un numero entero:");
            int tamanio = Int32.Parse(Console.ReadLine());

            int[,] matrizInversa = new int[tamanio, tamanio];

            for (int i = 0; i < matrizInversa.GetLength(0); i++)
            {
                for (int j = 0; j < matrizInversa.GetLength(1); j++)
                {
                    if ((i + j) == matrizInversa.GetLength(0) - 1)
                    {
                        matrizInversa[i, j] = 1;
                    }
                    else
                    {
                        matrizInversa[i, j] = 0;
                    }
                }
            }

            for (int i = 0; i < matrizInversa.GetLength(0); i++)
            {
                for (int j = 0; j < matrizInversa.GetLength(1); j++)
                {
                    Console.Write(matrizInversa[i, j] + "\t");
                }
                Console.WriteLine();
            }

        }
    }
}
