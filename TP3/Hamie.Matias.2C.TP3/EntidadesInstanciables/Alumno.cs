using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Alumno:Universitario
    {
        #region Campos
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region TiposAnidados
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        #endregion

        #region Métodos

        #region Constructores
        public Alumno()
            : base() { }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad) { }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
            this.claseQueToma = claseQueToma;
        }
        #endregion

        /// <summary>
        /// Completa la información pasada por el método ParticiparEnClase()
        /// </summary>
        /// <returns>Info del alumno</returns>
        protected override string MostrarDatos()
        {
            StringBuilder cadena = new StringBuilder(base.MostrarDatos());

            cadena.AppendLine(this.ParticiparEnClase());

            return cadena.ToString();
        }

        /// <summary>
        /// Da información de la clase q participa el alumno
        /// </summary>
        /// <returns>Info del alumno</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendFormat($"ESTADO DE CUENTA: {this.estadoCuenta}\n");
            cadena.AppendFormat($"TOMA CLASES DE: {this.claseQueToma}\n");
            return cadena.ToString();
        }

        /// <summary>
        /// Hace públicos los datos del alumno
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #region Sobrecarga de operadores
        /// <summary>
        /// Un alumno será igual a una clase si este la toma y no es deudor
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">Clase</param>
        /// <returns>true si no la toma, caso contrario false</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if (a.claseQueToma == clase)
            {
                if (a.estadoCuenta != EEstadoCuenta.Deudor)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Un alumno será distinto a una clase si no la toma
        /// </summary>
        /// <param name="a">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns>true si no la toma, caso contrario false</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            //return !(a == clase);
            return (a.claseQueToma != clase);
        }
        #endregion

        #endregion
    }
}
