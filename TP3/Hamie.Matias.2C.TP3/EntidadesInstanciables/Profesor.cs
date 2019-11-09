using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Profesor:Universitario
    {
        #region Campos
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region Métodos

        #region Constructores
        static Profesor()
        {
            random = new Random();
        }

        public Profesor()
            : base() { }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }
        #endregion

        protected override string ParticiparEnClase()
        {
            StringBuilder cadena = new StringBuilder();

            cadena.AppendLine("CLASES DEL DIA: \n");

            foreach (Universidad.EClases c in clasesDelDia)
            {
                cadena.AppendLine($"{c.ToString()}");
            }

            return cadena.ToString();
        }

        private void _randomClases()
        {
            //Para obtener la cantidad de strings del enum, uso GetNames para q me devuelva un array de strings
            //y con eso sacar el length que necesito para iterar y poner como max value en el random static
            int cantidadNombresClases = Enum.GetNames(typeof(Universidad.EClases)).Length;

            for (int i = 0; i < 2; i++)
            {
                this.clasesDelDia.Enqueue((Universidad.EClases)Profesor.random.Next(2));
            }
        }

        protected override string MostrarDatos()
        {
            StringBuilder cadena = new StringBuilder(base.MostrarDatos());

            cadena.AppendLine(this.ParticiparEnClase());

            return cadena.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #region Sobrecargas de operadores
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach (Universidad.EClases item in i.clasesDelDia)
            {
                if (item == clase) return true;
            }
            return false;
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion

        #endregion
    }
}
