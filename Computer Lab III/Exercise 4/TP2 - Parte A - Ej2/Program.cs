using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2___Parte_A___Ej2 {
    class Program {
        static void Main(string[] args) {
            try {
                Fraccion frac1 = new Fraccion(5, 8);
                Fraccion frac2 = new Fraccion(2, 0);
                Fraccion resultado = new Fraccion();

                resultado = frac1.sumar(frac1, frac2);
                Console.WriteLine("Resultado = {0}/{1}", resultado.getNumerador(), resultado.getDenominador());

                resultado = frac1.restar(frac1, frac2);
                Console.WriteLine("Resultado = {0}/{1}", resultado.getNumerador(), resultado.getDenominador());

                resultado = frac1.multiplicar(frac1, frac2);
                Console.WriteLine("Resultado = {0}/{1}", resultado.getNumerador(), resultado.getDenominador());

                resultado = frac1.dividir(frac1, frac2);
                Console.WriteLine("Resultado = {0}/{1}", resultado.getNumerador(), resultado.getDenominador());
            } catch (FraccionException fe) {
                Console.WriteLine(fe.Message);
            }
        }
    }
}
