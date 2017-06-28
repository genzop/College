using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2___Parte_B___Ej2 {
    class Program {
        static void Main(string[] args) {
            int[] numero = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            foreach (int num in numero) {
                Console.WriteLine(num.ToString());
            }
        }
    }
}
