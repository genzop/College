using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto6
{
    class Gestor
    {

        public int[] unirMatrices(int[] matriz1, int[] matriz2)
        {
            int[] matriz3 = new int[matriz1.Length + matriz2.Length];
            try
            {
                for (int i = 0; i < matriz1.Length; i++)
                {
                    if (matriz1[i] < matriz2[i])
                    {
                        matriz3[i * 2] = matriz1[i];
                        matriz3[(i * 2) + 1] = matriz2[i];
                    }
                    if (matriz1[i] > matriz2[i])
                    {
                        matriz3[i * 2] = matriz2[i];
                        matriz3[(i * 2) + 1] = matriz1[i];
                    }
                    if (matriz1[i] == matriz2[i])
                    {
                        matriz3[i * 2] = matriz1[i];
                        matriz3[(i * 2) + 1] = matriz2[i];
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            return matriz3;
        }
    }
}
