using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2___Parte_A___Ej3 {
    class NumeroNoEnteroException : Exception {
        public NumeroNoEnteroException() : base("no es un numero entero.") { }
    }
}
