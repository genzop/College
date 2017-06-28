using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto4
{
    class Gestor
    {
        public string eliminarLetras(string cadena)
        {
            string cadenaSinLetras = "";
            string[] numeros = new string[10] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            try
            {
                foreach (char c in cadena)
                {
                    for (int i = 0; i < numeros.Length; i++)
                    {
                        if (c.ToString() == numeros[i])
                        {
                            cadenaSinLetras += c;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }  
            return cadenaSinLetras;
        }

    }
}
