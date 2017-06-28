using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2___Parte_A___Ej2 {
    class Fraccion {

        private int numerador;
        private int denominador;

        public Fraccion() {}

        public Fraccion(int numerador, int denominador) {
            if (denominador == 0) {
                throw new FraccionException();
            }
            this.numerador = numerador;
            this.denominador = denominador;
        }

        public int getNumerador() {
            return this.numerador;
        }
        public void setNumerador(int numerador) {
            this.numerador = numerador;
        }
        public int getDenominador() {
            return this.denominador;
        }
        public void setDenominador(int denominador) {
            this.denominador = denominador;
        }

        public Fraccion sumar(Fraccion frac1, Fraccion frac2) {

            Fraccion resultado = new Fraccion();
            if (frac1.getDenominador() == frac2.getDenominador()) {
                resultado.setDenominador(frac1.getDenominador());
                resultado.setNumerador(frac1.getNumerador() + frac2.getNumerador());
            } else {
                Console.WriteLine("Error: Ambas fracciones deben tener el mismo denominador para ser sumadas");
            }
            return resultado;
        }

        public Fraccion restar(Fraccion frac1, Fraccion frac2) {
            Fraccion resultado = new Fraccion();
            if (frac1.getDenominador() == frac2.getDenominador()) {
                resultado.setDenominador(frac1.getDenominador());
                resultado.setNumerador(frac1.getNumerador() - frac2.getNumerador());
            } else {
                Console.WriteLine("Error: Ambas fracciones deben tener el mismo denominador para ser restadas");
            }
            return resultado;
        }

        public Fraccion multiplicar(Fraccion frac1, Fraccion frac2) {
            Fraccion resultado = new Fraccion();
            resultado.setNumerador(frac1.getNumerador() * frac2.getNumerador());
            resultado.setDenominador(frac1.getDenominador() * frac2.getDenominador());
            return resultado;
        }

        public Fraccion dividir(Fraccion frac1, Fraccion frac2) {
            Fraccion resultado = new Fraccion();
            resultado.setNumerador(frac1.getNumerador() * frac2.getDenominador());
            resultado.setDenominador(frac1.getDenominador() * frac2.getNumerador());
            if (resultado.getDenominador() == 0) {
                throw new FraccionException();
            }
            return resultado;
        }
    }
}
