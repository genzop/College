using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3___Ej3 {
    class CuentaBancaria {
        private string titularCta;
        private string cuit;
        private decimal saldo;
        private long numeroCBU;

        public CuentaBancaria() {}

        public string getTitularCta() {
            return this.titularCta;
        }
        public void setTitularCta(string titularNuevo) {
            this.titularCta = titularNuevo;
        }

        public string getCuit() {
            return this.cuit;
        }

        public void setCuit(string cuitNuevo) {
            this.cuit = cuitNuevo;
        }

        public decimal getSaldo() {
            return this.saldo;
        }

        public void setSaldo(decimal saldoNuevo) {
            this.saldo = saldoNuevo;
        }

        public long getNumeroCBU() {
            return this.numeroCBU;
        }

        public void setNumeroCBU(long numeroCBUNuevo) {
            this.numeroCBU = numeroCBUNuevo;
        }
    }
}
