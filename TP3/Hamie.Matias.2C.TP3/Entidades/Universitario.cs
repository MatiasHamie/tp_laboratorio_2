using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario:Persona
    {
        #region Campos
        private int legajo;
        #endregion

        #region Métodos

        #region Constructores
        public Universitario()
          :base(){ }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        #endregion

        /// <summary>
        /// Compara que el tipo de dato sea universitario
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return ((obj is Universitario) && (this == (Universitario)obj));
            //return obj is Universitario;
        }

        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Muestra datos del Universitario
        /// </summary>
        /// <returns>string con datos del universitario</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder cadena = new StringBuilder(base.ToString());

            cadena.AppendFormat($"LEGAJO NúMERO: {this.legajo}\n");

            return cadena.ToString();
        }

        #region Sobrecarga de operadores
        /// <summary>
        /// Compara que dos universitarios sean iguales por DNI o Legajo
        /// </summary>
        /// <param name="pg1">Universitario 1</param>
        /// <param name="pg2">Universitario 2</param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return ((pg1.legajo == pg2.legajo) || (pg1.DNI == pg2.DNI));
        }

        /// <summary>
        /// Compara que dos universitarios sean distintos
        /// </summary>
        /// <param name="pg1">Universitario 1</param>
        /// <param name="pg2">Universitario 2</param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion

        #endregion
    }
}
