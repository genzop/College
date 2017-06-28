using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2___Parte_A___Ej2 {
    class FraccionException : Exception {
        public FraccionException() : base("Error: fraccion con denominador 0") { }
    }
}
