using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3___Ej4 {
    class Program {
        static void Main(string[] args) {

            List<Figura> figuras = new List<Figura>();
            Rectangulo rectangulo = new Rectangulo();
            Circulo circulo = new Circulo();
            Triangulo triangulo = new Triangulo();

            figuras.Add(rectangulo);            
            figuras.Add(circulo);
            figuras.Add(triangulo);
            
            foreach (Figura fig in figuras) {
                fig.dibujar();
            }

        }
    }
}
