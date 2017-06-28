using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TP3___Ej1 {
    class Program {
        static void Main(string[] args) {
            for (int i = 0; i < 20; i++) {
                ejecutarHilo();
                Thread.Sleep(TimeSpan.FromSeconds(30));
            }           
        }

        static void ejecutarHilo() {
            Console.WriteLine("HILO EJECUTADO");
        }
    }
}
