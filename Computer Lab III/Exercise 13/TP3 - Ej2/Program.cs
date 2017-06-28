using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3___Ej2 {
    class Program {
        static void Main(string[] args) {
            CuentaBancaria cuenta1 = new CuentaBancaria();
            cuenta1.titularCta = "Juan Alonso";
            cuenta1.cuit = "20-26987456-7";
            cuenta1.saldo = 1258.75m;
            cuenta1.numeroCBU = 1236547896554;

            CuentaBancaria cuenta2 = new CuentaBancaria();
            cuenta2.titularCta = "Alberto Lopez";
            cuenta2.cuit = "23-15654321-9";
            cuenta2.saldo = 25698.78m;
            cuenta2.numeroCBU = 9876546546557;
        }
    }
}
