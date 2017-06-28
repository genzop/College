using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseParcial {
    class Program {
        static void Main(string[] args) {
            Rectangulo rectangulo = new Rectangulo();
            rectangulo.setAlto(5);
            rectangulo.setAncho(10);

            Console.WriteLine("Superficie: {0}", rectangulo.retornarSuperficie());
            Console.WriteLine("Perimetro: {0}", rectangulo.retornarPerimetro());            
        }
    }
}
