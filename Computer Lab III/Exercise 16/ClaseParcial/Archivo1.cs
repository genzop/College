using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseParcial {
    partial class Rectangulo {

        private int ancho;
        private int alto;

        public Rectangulo() {}

        public int getAncho() {
            return this.ancho;
        }

        public void setAncho(int anchoNuevo) {
            this.ancho = anchoNuevo;
        }

        public int getAlto() {
            return this.alto;
        }

        public void setAlto(int altoNuevo) {
            this.alto = altoNuevo;
        }
    }
}
