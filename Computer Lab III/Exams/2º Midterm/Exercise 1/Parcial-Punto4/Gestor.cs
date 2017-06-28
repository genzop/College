using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial_Punto4
{
    class Gestor
    {
        //D:\Puesto 2.2\Documentos\Visual Studio 2015\Projects\Parcial-Punto4\numeros.txt

        public void leerArchivo(string ubicacion)
        {
            StreamReader reader = new StreamReader(ubicacion);
            string linea = reader.ReadLine();
            string[] cadNumeros  = linea.Split('-');
            string pares = "Pares: ";
            string impares = "Impares: ";

            foreach (string num in cadNumeros)                
            {
                if (Convert.ToInt32(num) % 2 == 0)
                {
                    pares += num + ", ";
                }
                else
                {
                    impares += num + ", ";
                }
            }
           
            Console.WriteLine(pares);
            Console.WriteLine(impares);
        }

    }
}
