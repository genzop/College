using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3___Ej2 {
    class CuentaBancaria {

        public string titularCta;
        public string cuit;
        public decimal saldo;
        public long numeroCBU;

        public CuentaBancaria() {}
        
        public CuentaBancaria(string titularCta, string cuit, decimal saldo, int numeroCBU) {
            this.titularCta = titularCta;
            this.cuit = cuit;
            this.saldo = saldo;
            this.numeroCBU = numeroCBU;
        }

    }
}
