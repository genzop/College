using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseParcial {
    partial class Rectangulo {

        public int retornarSuperficie() {
            return ancho * alto;
        }

        public int retornarPerimetro() {
            return ancho * 2 + alto * 2;
        } 
    }
}
