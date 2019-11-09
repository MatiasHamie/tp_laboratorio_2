using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor)
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        #endregion

        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder(base.ToString());

            cadena.AppendLine("- JORNADA -");
            cadena.AppendFormat($"CLASE DE {this.clase} POR NOMBRE COMPLETO: {this.instructor}\n");
            cadena.AppendLine("ALUMNOS: ");
            foreach (Alumno item in this.alumnos)
            {
                cadena.AppendFormat($"NOMBRE COMPLETO: {item.ToString()}");
            }

            cadena.AppendLine("<-------------->");

            return cadena.ToString();
        }

        public bool Guardar(Jornada jornada)
        {
             
        }

        public string Leer()
        {

        }

        #region Sobrecarga de operadores
        public static bool operator ==(Jornada j, Alumno a)
        {
            return j.alumnos.Contains(a);
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
