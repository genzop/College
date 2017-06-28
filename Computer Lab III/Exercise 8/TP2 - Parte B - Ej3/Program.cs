using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2___Parte_B___Ej3 {
    class Program {

        static void Main(string[] args) {
            CallMyMethod(6, 2, true);
        }

        static void CallMyMethod(int num1, int num2, bool criterio) {
            if (criterio) {
                Console.WriteLine(num1 * num2);
            } else {
                Console.WriteLine(num1 / num2);
            }
        }
    }
}
