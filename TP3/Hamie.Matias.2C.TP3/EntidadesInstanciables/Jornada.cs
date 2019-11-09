using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        #region Campos
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion

        #region Propiedades
        public List<Alumno> Alumnos { get { return this.alumnos; } set { this.alumnos = value; } }

        public Universidad.EClases Clase { get { return this.clase; } set { this.clase = value; } }

        public Profesor Instructor { get { return this.instructor; } set { this.instructor = value; } }
        #endregion

        #region Métodos

        #region Constructores
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        #endregion

        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder();

            cadena.AppendFormat($"CLASE DE {this.clase} POR {this.instructor.ToString()}\n");
            cadena.AppendLine("ALUMNOS: ");
            foreach (Alumno item in this.alumnos)
            {
                cadena.AppendFormat($"{item.ToString()}");
            }

            cadena.AppendLine("<-------------->");

            return cadena.ToString();
        }

        #region Archivos
        public static bool Guardar(Jornada jornada)
        {
            Texto archivoTexto = new Texto();
            return archivoTexto.Guardar("Jornada_Texto_Hamie", jornada.ToString());
        }

        public static string Leer()
        {
            string datos = "";

            Texto archivoTexto = new Texto();
            archivoTexto.Leer("Jornada_Texto_Hamie", out datos);

            return datos;
        }
        #endregion

        #region Sobrecarga de operadores
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno alumnoAux in j.alumnos)
            {
                if (alumnoAux == a)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.alumnos.Add(a);
            }

            return j;
        }
        #endregion

        #endregion
    }
}
