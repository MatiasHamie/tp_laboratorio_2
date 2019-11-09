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

        private string MostrarDatos(Universidad uni)
        {
            StringBuilder cadena = new StringBuilder();

            cadena.AppendLine("JORNADA: ");

            foreach (Jornada jornada in uni.Jornadas)
            {
                cadena.AppendLine(jornada.ToString());
            }

            cadena.AppendLine("<--------------->");

            return cadena.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos(this);
        }


        #region Sobrecarga de operadores
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
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
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
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
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
        public static Profesor operator !=(Universidad g, Universidad.EClases clase)
        {
            try
            {
                foreach (Profesor profesor in g.Instructores)
                {
                    if (profesor != clase)
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

        public static Universidad operator +(Universidad g, Universidad.EClases clase)
        {
            Profesor profesorDisponible = (g == clase);

            if (!(profesorDisponible is null))
            {
                Jornada jornada = new Jornada(clase, profesorDisponible);

                foreach (Alumno a in g.alumnos)
                {
                    if (a == clase)
                    {
                        jornada.Alumnos.Add(a);
                    }
                }
                g.jornada.Add(jornada);
            }

            return g;
        }
        #endregion

        #endregion
    }
}
