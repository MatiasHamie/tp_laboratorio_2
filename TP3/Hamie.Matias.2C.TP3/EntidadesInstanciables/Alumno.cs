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

        protected override string MostrarDatos()
        {
            StringBuilder cadena = new StringBuilder(base.MostrarDatos());

            cadena.AppendLine(this.ParticiparEnClase());

            return cadena.ToString();
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendFormat($"ESTADO DE CUENTA: {this.estadoCuenta}\n");
            cadena.AppendFormat($"TOMA CLASES DE: {this.claseQueToma}\n");
            return cadena.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #region Sobrecarga de operadores
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

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a == clase);
        }
        #endregion

        #endregion
    }
}
