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
        }
        #endregion

        protected override string ParticiparEnClase()
        {
            StringBuilder cadena = new StringBuilder();

            cadena.AppendLine("CLASES DEL DIA: \n");

            for (int i = 0; i < this.clasesDelDia.Count; i++)
            {
                cadena.AppendFormat($"{this.clasesDelDia.Dequeue()}\n");
            }

            return cadena.ToString();
        }

        private void _randomClases()
        {
            //Para obtener la cantidad de strings del enum, uso GetNames para q me devuelva un array de strings
            //y con eso sacar el length que necesito para iterar y poner como max value en el random static
            int cantidadNombresClases = Enum.GetNames(typeof(Universidad.EClases)).Length;

            for (int i = 0; i < cantidadNombresClases; i++)
            {
                this.clasesDelDia.Enqueue((Universidad.EClases)Profesor.random.Next(cantidadNombresClases));
            }
        }

        protected override string MostrarDatos()
        {
            return this.ToString();
        }

        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder(base.MostrarDatos());

            cadena.Append(this.ParticiparEnClase());

            return cadena.ToString();
        }

        #region Sobrecargas de operadores
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            //Si la cola contiene la clase devuelvo true
            return (i.clasesDelDia.Contains(clase));
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion

        #endregion
    }
}
