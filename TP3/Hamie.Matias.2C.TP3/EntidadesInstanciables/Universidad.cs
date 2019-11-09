using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace EntidadesInstanciables
{
    public class Universidad
    {
        #region Campos
        List<Alumno> alumnos;
        List<Jornada> jornada;
        List<Profesor> profesores;
        #endregion

        #region Propiedades
        public List<Alumno> Alumnos { get { return this.alumnos; } set { this.alumnos = value; } }
        public List<Profesor> Instructores { get { return this.profesores; } set { this.profesores = value; } }
        public List<Jornada> Jornadas { get { return this.jornada; } set { this.jornada = value; } }

        public Jornada this[int index]
        {
            get { return this.jornada[index]; }
            set { this.jornada[index] = value; }
        }
        #endregion

        #region TiposAnidados
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        #endregion

        #region Métodos

        #region Constructores
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.profesores = new List<Profesor>();
            this.jornada = new List<Jornada>();
        }
        #endregion

        /// <summary>
        /// Guarda en formato ".xml" info de la universidad
        /// </summary>
        /// <param name="uni"></param>
        /// <returns>true si pudo, caso contrario false</returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            try
            {
                xml.Guardar("Universidades_Xml_Hamie.txt", uni);
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return false;
        }

        /// <summary>
        /// Lee info de una universidad en formato ".xml"
        /// </summary>
        /// <returns>Una universidad con datos</returns>
        public static Universidad Leer()
        {
            Universidad universidad = new Universidad();
            try
            {
                Xml<Universidad> xml = new Xml<Universidad>();
                xml.Leer("Universidades_Xml_Hamie.txt", out universidad);
                return universidad;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        /// <summary>
        /// Muestra info de la universidad
        /// </summary>
        /// <param name="uni"></param>
        /// <returns>string info de la universidad</returns>
        private string MostrarDatos(Universidad uni)
        {
            StringBuilder cadena = new StringBuilder();

            cadena.AppendLine("JORNADA: ");

            foreach (Jornada jornada in uni.Jornadas)
            {
                cadena.AppendLine(jornada.ToString());
            }

            return cadena.ToString();
        }

        /// <summary>
        /// Hace públicos los datos de la universidad
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }


        #region Sobrecarga de operadores

        /// <summary>
        /// Verifica si un alumno ya se encuentra en la jornada
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>true si ya existe, caso contrario false</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno alumnoAux in g.alumnos)
            {
                if (alumnoAux == a)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Verifica que no exista el alumno en la jornada
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>true si no existe, caso contrario false</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Verifica que el profesor esté dando clases en la universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>true si está dando clases, caso contrario false</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor profesorAux in g.Instructores)
            {
                if (profesorAux == i)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Verifica que no exista el profesor en la jornada
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>true si no existe, caso contrario false</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Compara universidad con clase
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns> Retorna el primer profesor capaz de dar la clase</returns>
        public static Profesor operator ==(Universidad g, Universidad.EClases clase)
        {
            try
            {
                foreach (Profesor profesor in g.Instructores)
                {
                    if (profesor == clase)
                    {
                        return profesor;
                    }
                }
            }
            catch (Exception)
            {
                throw new SinProfesorException();
            }

            return null;
        }

        /// <summary>
        /// Compara universidad con clase
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns> Retorna el primer profesor capaz de dar la clase</returns>
        public static Profesor operator !=(Universidad g, Universidad.EClases clase)
        {
            foreach (Profesor profesor in g.Instructores)
            {
                if (profesor != clase)
                {
                    return profesor;
                }
            }
            
            return null;
        }

        /// <summary>
        /// Agrega un alumno a la jornada, verificando que no se repita
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>Universidad con alumno nuevo</returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g != a)
            {
                g.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }

            return g;
        }

        /// <summary>
        /// Agrega un profesor a la universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>Universidad con profesor nuevo</returns>
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g != i)
            {
                g.Instructores.Add(i);
            }
            else
            {
                throw new SinProfesorException();
            }

            return g;
        }

        /// <summary>
        /// Agrega una jornada a la universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns>Universidad con nueva jornada</returns>
        public static Universidad operator +(Universidad g, Universidad.EClases clase)
        {
            Profesor profesorDisponible = (g == clase);
            
            if(!(profesorDisponible is null))
            {
                Jornada jornada = new Jornada(clase, profesorDisponible);
                List<Alumno> jornadaNuevaAlumnos = new List<Alumno>();

                foreach (Alumno a in g.alumnos)
                {
                    if (a == clase)
                    {
                        jornadaNuevaAlumnos.Add(a);
                    }
                }
                jornada.Alumnos = jornadaNuevaAlumnos;

                g.jornada.Add(jornada);
            }

            return g;
        }
        #endregion

        #endregion
    }
}
