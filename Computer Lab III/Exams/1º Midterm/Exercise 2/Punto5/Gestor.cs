using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto5
{
    class Gestor
    {
        public int[] cargarNumeros()
        {
            int[] numeros = new int[10];
            string num;
            try
            {
                for (int i = 0; i < numeros.Length; i++)
                {
                    do
                    {
                        Console.WriteLine("Ingrese el " + (i + 1) + "º numero:");
                        num = Console.ReadLine();
                    }
                    while (Int32.Parse(num) < 0);
                    numeros[i] = Int32.Parse(num);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }            
            return numeros;
        }

        public int sumaRecursiva(int[] arreglo, int posicion)
        {
            int suma = 0;
            try
            {
                suma += arreglo[posicion];
                if (posicion == arreglo.Length - 1)
                { }
                else
                {
                    suma += sumaRecursiva(arreglo, posicion + 1);                    
                }               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            return suma;
        }
    }
}
