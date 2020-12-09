using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaDeCafeWinf
{
    class Cafe
    {

        public string NomeCafe { get; private set; }
        public double PrecoCafe { get; set; }
        public Cafe(string nome, double preco)
        {
            NomeCafe = nome;
            PrecoCafe = preco;
        }
    }
}
