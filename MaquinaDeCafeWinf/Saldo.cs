using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaDeCafeWinf
{
    class Saldo
    {
        public double SaldoFinal { get; set; }
        public decimal ValorMoeda { get; set; }
        public string NomeMoeda { get; set; }

        public double Moeda1Real = 1.0;
        public double Moeda50Centavos = 0.50;
        public double Moeda25Centavos = 0.25;
        public double Moeda10Centavos = 0.10;
        public double Moeda05Centavos = 0.05;
        public double Moeda01Centavo = 0.01;

        public int Qnt1Real(double saldo)
        {
            if (SaldoFinal >= 1.0)
            {
                SaldoFinal += saldo;
                double qntMoedas = saldo / Moeda1Real;
                return (int)qntMoedas;
            }
            return 0;
        }
        public int Qnt50Centavos(double saldo)
        {
            if (SaldoFinal >= 0.50)
            {
                SaldoFinal += saldo;
                double qntMoedas = saldo / Moeda50Centavos;
                return (int)qntMoedas;
            }
                return 0;
        }
        public int Qnt25Centavos(double saldo)
        {
            //saldo += Math.Round(saldo, 2, MidpointRounding.AwayFromZero);
            if (saldo >= 0.25)
            {
                SaldoFinal += saldo;
                double qntMoedas = saldo / Moeda25Centavos;
                return (int)qntMoedas;
            }
                return 0;
        }
        public int Qnt10Centavos(double saldo)
        {
            //saldo += Math.Round(saldo, 2, MidpointRounding.AwayFromZero);
            if (saldo >= 0.10)
            {
                SaldoFinal += saldo;
                double qntMoedas = saldo / Moeda10Centavos;
                return (int)qntMoedas;
            }
                return 0;
        }
        public int Qnt5Centavos(double saldo)
        {
            if (saldo >= 0.05)
            {
                SaldoFinal += saldo;
                double qntMoedas = saldo / Moeda50Centavos;
                return (int)qntMoedas;
            }
                return 0;
        }
        public int Qnt1Centavo(double saldo)
        {
            saldo += Math.Round(saldo, 2, MidpointRounding.AwayFromZero);
            if (saldo >= 0.1)
            {
                SaldoFinal += saldo;
                double qntMoedas = saldo / Moeda01Centavo;
                return (int)qntMoedas;
            }
                return 0;
        }
    }
}
