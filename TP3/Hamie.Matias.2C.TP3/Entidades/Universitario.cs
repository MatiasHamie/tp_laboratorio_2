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
        int legajo;
        #endregion

        #region Métodos

        #region Constructores
        public Universitario()
          :base(){ }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        { }

        #endregion

        public override bool Equals(object obj)
        {
            return (obj is Universitario && this == (Universitario)obj);
        }

        protected abstract string ParticiparEnClase();

        protected virtual string MostrarDatos()
        {
            StringBuilder cadena = new StringBuilder(base.ToString());

            cadena.AppendFormat($"LEGAJO NúMERO: {this.legajo}\n");

            return cadena.ToString();
        }

        #region Sobrecarga de operadores
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return (pg1.Equals(pg2) && (pg1.legajo == pg2.legajo) || (pg1.DNI == pg2.DNI));
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return pg1 != pg2;
        }
        #endregion

        #endregion
    }
}
