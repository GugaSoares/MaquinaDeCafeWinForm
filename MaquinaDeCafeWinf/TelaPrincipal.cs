using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace MaquinaDeCafeWinf
{
    public partial class TelaInicial : Form
    {
        public TelaInicial()
        {
            InitializeComponent();
            SetInicio();
        }

        public void SetInicio()
        {
            cappuccinoBtn.Enabled = false;
            mochaBtn.Enabled = false;
            cafeComLeiteBtn.Enabled = false;

            cappuccinoCf.Enabled = false;
            mochaCf.Enabled = false;
            cafeComLeiteCf.Enabled = false;
            saldoTxt.Text = s.SaldoFinal.ToString("C2");
            receberTrocoBtn.Enabled = false;
            receberTrocoBtn.Visible = false;
            groupBoxTroco.Enabled = false;
            groupBoxTroco.Visible = false;

        }
        List<double> moedasInseridas = new List<double>();
        Saldo s = new Saldo();
        double saldoInteiro;

        // Botões de compra 
        private void mochaBtn_Click(object sender, EventArgs e)
        {
            mochaCf.Enabled = true;
            cafeComLeiteBtn.Enabled = false;
            cappuccinoBtn.Enabled = false;
        }

        private void cafeComLeiteBtn_Click(object sender, EventArgs e)
        {
            cafeComLeiteCf.Enabled = true;
            cappuccinoBtn.Enabled = false;
            mochaBtn.Enabled = false;
        }
        private void cappuccinoBtn_Click(object sender, EventArgs e)
        {
            cappuccinoCf.Enabled = true;
            mochaBtn.Enabled = false;
            cafeComLeiteBtn.Enabled = false;
        }

        //Moedas


        private void moeda1Btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Defeito na leitora de moedas, insira uma moeda de outro valor", "Defeito", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void moeda5Btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Defeito na leitora de moedas, insira uma moeda de outro valor", "Defeito", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void moeda10Btn_Click(object sender, EventArgs e)
        {
            SomaMoedas(0.10);
        }

        private void moeda25Btn_Click(object sender, EventArgs e)
        {
            SomaMoedas(0.25);
        }
        private void moeda50Btn_Click(object sender, EventArgs e)
        {
            SomaMoedas(0.50);
        }
        private void moeda1RealBtn_Click(object sender, EventArgs e)
        {
            SomaMoedas(1.0);
        }
        public void SomaMoedas(double moeda)
        {
            while (true)
            {
                moedasInseridas.Add(moeda);
                s.SaldoFinal = moedasInseridas.Sum();
                saldoTxt.Text = s.SaldoFinal.ToString("C2");

                if (s.SaldoFinal >= 4.0)
                {
                    mochaBtn.Enabled = true;
                    cappuccinoBtn.Enabled = true;
                    cafeComLeiteBtn.Enabled = true;
                }
                else if (s.SaldoFinal >= 3.5)
                {
                    cappuccinoBtn.Enabled = true;
                    cafeComLeiteBtn.Enabled = true;
                }
                else if (s.SaldoFinal >= 3.0)
                {
                    cafeComLeiteBtn.Enabled = true;
                }
                return;
            }
        }

        //Botões para seleção de café
        private void cappuccinoCf_Click(object sender, EventArgs e)
        {
            Cafe cappuccino = new Cafe("Cappuccino", 3.5);
            SaldoTroco(cappuccino.NomeCafe, cappuccino.PrecoCafe);
        }
        private void cafeComLeiteCf_Click(object sender, EventArgs e)
        {
            Cafe cafeComLeite = new Cafe("Café com leite", 3.0);
            SaldoTroco(cafeComLeite.NomeCafe, cafeComLeite.PrecoCafe);
        }
        private void mochaCf_Click(object sender, EventArgs e)
        {
            Cafe mocha = new Cafe("Mocha", 4.0);
            SaldoTroco(mocha.NomeCafe, mocha.PrecoCafe);
        }

        private void SaldoTroco(string nomeCafe, double precoCafe)
        {
            try
            {
                s.SaldoFinal -= precoCafe;
                saldoInteiro = s.SaldoFinal;

                if (s.SaldoFinal != 0.0)
                {
                    receberTrocoBtn.Enabled = true;
                    receberTrocoBtn.Visible = true;
                    Troco(s.SaldoFinal); //Adicionar método de troco
                }
                else
                {
                    MessageBox.Show("Saboreie seu " + nomeCafe, "Compra realizada com sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao realizar a compra!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Troco(double saldo)
        {
            groupBoxTroco.Visible = true;
            //Retorna quantidade de moedas trocado
            saldo = Math.Round(saldo, 2, MidpointRounding.AwayFromZero);
            int qntMoeda1 = s.Qnt1Real(saldo);
            troco1RealTxt.Text = qntMoeda1.ToString();
            saldo -= qntMoeda1 * 1.0;

            saldo = Math.Round(saldo, 2, MidpointRounding.AwayFromZero);
            int qntMoeda50 = s.Qnt50Centavos(saldo);
            troco50CentsTxt.Text = qntMoeda50.ToString();
            saldo -= qntMoeda50 * 0.50;

            saldo = Math.Round(saldo, 2, MidpointRounding.AwayFromZero);
            int qntMoeda25 = s.Qnt25Centavos(saldo);
            troco25CentsTxt.Text = qntMoeda25.ToString();
            saldo -= qntMoeda25 * 0.25;

            saldo = Math.Round(saldo, 2, MidpointRounding.AwayFromZero);
            int qntMoeda10 = s.Qnt10Centavos(saldo);
            troco10CentsTxt.Text = qntMoeda10.ToString();
            saldo -= qntMoeda10 * 0.10;

            saldo = Math.Round(saldo, 2, MidpointRounding.AwayFromZero);
            int qntMoeda05 = s.Qnt5Centavos(saldo);
            troco5CentsTxt.Text = qntMoeda05.ToString();
            saldo -= qntMoeda05 * 0.05;

            saldo = Math.Round(saldo, 2, MidpointRounding.AwayFromZero);
            int qntMoeda01 = s.Qnt1Centavo(saldo);
            troco1CentTxt.Text = qntMoeda01.ToString();
        }
        public void Reset()
        {
            s.SaldoFinal = 0.0;
            moedasInseridas.Clear();
            SetInicio();
        }
        private void receberTrocoBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Obrigado pela compra!!! Troco de " + saldoInteiro.ToString("C2") + ". Aproveite seu café!!!", "Troco recebido!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Reset();
        }
    }
}





