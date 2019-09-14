using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;//Agregado manualmente la referencia (click derecho en referencias->agregar)

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperador.Text = "";
            lblResultado.Text = "";
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero auxNum1 = new Numero(numero1);
            Numero auxNum2 = new Numero(numero2);

            return Calculadora.Operar(auxNum1, auxNum2, operador);
        }

        private void BtnOperar_Click(object sender, EventArgs e)
        {
            double resultado = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);
            string strResultado=resultado.ToString();
            lblResultado.Text = strResultado;
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (Calculadora.conversionFlag == 0)
            {
                Numero numeroAConvertir = new Numero(lblResultado.Text);
                string aux = numeroAConvertir.DecimalBinario(lblResultado.Text);
                Calculadora.conversionFlag = 1;
                lblResultado.Text = aux;
            }
        }

        private void Btn_ConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (Calculadora.conversionFlag == 1) 
            {
                Numero numeroAConvertir = new Numero(lblResultado.Text);
                string aux = numeroAConvertir.BinarioDecimal(lblResultado.Text);
                Calculadora.conversionFlag = 0;
                lblResultado.Text = aux;
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
