using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;
            operador = ValidarOperador(operador);

            switch (operador)
            {
                //Recordar sobrecarga de operadores ya realizada
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
            }

            return resultado;
        }

        private static string ValidarOperador(string operador)
        {
            string operadorValidado = "";
            switch (operador)
            {
                case "+":
                    operadorValidado = "+";
                    break;
                case "-":
                    operadorValidado = "-";
                    break;
                case "*":
                    operadorValidado = "*";
                    break;
                case "/":
                    operadorValidado = "/";
                    break;
                default:
                    operadorValidado = "+";
                    break;
            }

            return operadorValidado;
        }
    }
}
