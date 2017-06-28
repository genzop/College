using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2___Parte_B___Ej1 {
    class Program {
        static void Main(string[] args) {
            int objetoCuenta = 50;
            incrementaValor(objetoCuenta);
            int sufijoValor = objetoCuenta++;
            int prefijoValor = ++objetoCuenta;
            decremetaValor(prefijoValor);
            Console.WriteLine("ObjetoCuenta: {0}", objetoCuenta);
            Console.WriteLine("SufijoValor: {0}", sufijoValor);
            Console.WriteLine("PrefijoValor: {0}", prefijoValor);
        }

        static void incrementaValor(int  valor) {
            ++valor;
        } 
        static void decremetaValor(int valor) {
            --valor;
        }
    }
}
