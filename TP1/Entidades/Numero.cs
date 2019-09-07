using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        #region Constructores
        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            SetNumero(strNumero);
        }
        #endregion

        public void SetNumero(string strNumero)
        {
            this.numero = ValidarNumero(strNumero);
        }

        private double ValidarNumero(string strNumero)
        {
            double aux;
            if(double.TryParse(strNumero,out aux))
            {
                return aux;
            }
            else
            {
                return 0;
            }
        }

        #region Sobrecarga de operadores
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero == 0)
            {
                return double.MinValue;
            }
            else
            {
                return n1.numero / n2.numero;
            }
        }
        #endregion

        #region Conversiones
        public string BinarioDecimal(string binario)
        {
            char[] auxiliarBinario = binario.ToCharArray();//Paso a array
            double binarioConvertido = 0;

            Array.Reverse(auxiliarBinario);//Lo invierto para 

            for (int indicePotencia = 0; indicePotencia < auxiliarBinario.Length; indicePotencia++)
            {
                if (auxiliarBinario[indicePotencia] == '1')
                {
                    binarioConvertido += Math.Pow(indicePotencia, 2);
                }
            }

            if (binarioConvertido != 0)
            {
                return binarioConvertido.ToString();
            }
            else //Si nunca encontró un 1, lo doy inválido
            {
                return "Valor inválido";
            }
        }

        public string DecimalBinario(string numero)
        {
            Numero auxiliarConversion = new Numero(numero);
            string resultadoBinario = "";

            while (auxiliarConversion.numero > 1)
            {
                if (auxiliarConversion.numero % 2 == 0)
                {
                    resultadoBinario += "0";
                }
                else if(auxiliarConversion.numero==0)
                {
                    resultadoBinario += "0";
                }
                else
                {
                    resultadoBinario += "1";
                }

                //Como la division no se le asigna a ningun numero, lo hago fuera de los if asignándolo
                auxiliarConversion.numero /= 2;
            }

            return resultadoBinario;
        }

        public string DecimalBinario(double numero)
        {
            string strNumero = numero.ToString();
            return DecimalBinario(strNumero);
        }
        #endregion

    }
}
