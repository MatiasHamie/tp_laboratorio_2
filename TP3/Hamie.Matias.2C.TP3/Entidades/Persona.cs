using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region Campos
        private string apellido;
        private string nombre;
        private int dni;
        private ENacionalidad nacionalidad;
        #endregion

        #region Tipos Anidados
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion

        #region Propiedades
        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = ValidarNombreApellido(value); }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = ValidarNombreApellido(value); }
        }

        public int DNI
        {
            get { return this.dni; }
            set { this.dni = ValidarDni(this.nacionalidad, value); }
        }

        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set { this.nacionalidad = value; }
        }

        public string StringToDNI
        {
            set { this.dni = ValidarDni(this.nacionalidad, value); }
        }

        #endregion

        #region Métodos

        #region Constructores
        public Persona() { }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
            : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) :
            this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        /// <summary>
        /// Muestra informacion de la persona
        /// </summary>
        /// <returns>Info de la persona</returns>
        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder();

            cadena.AppendFormat($"NOMBRE COMPLETO: {this.apellido}, {this.nombre}\n");
            cadena.AppendFormat($"Nacionalidad: {this.nacionalidad}\n");
            cadena.AppendFormat($"DNI: {this.dni}\n");

            return cadena.ToString();
        }

        /// <summary>
        /// Valida DNI Extranjero o Argentino
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad</param>
        /// <param name="dato">DNI</param>
        /// <returns>si es valido el DNI, caso contrario -1</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int retorno = -1;
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato > 1 && dato <= 89999999) 
                    {
                        retorno = dato;
                    }
                    else
                    {
                        throw new NacionalidadInvalidaException("Dni argentino inválido");
                    }
                    break;
                case ENacionalidad.Extranjero:
                    if (dato > 90000000 && dato <= 99999999) 
                    {
                        retorno = dato;
                    }
                    else
                    {
                        throw new NacionalidadInvalidaException("Dni extranjero inválido");
                    }
                    break;
            }

            return retorno;
        }

        /// <summary>
        /// Valida DNI recibido como string
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad</param>
        /// <param name="dato">DNI</param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad,string dato)
        {
            int auxiliarDNI = 0;

            if(int.TryParse(dato,out auxiliarDNI))
            {
                return this.ValidarDni(nacionalidad, auxiliarDNI);
            }
            else
            {
                throw new DniInvalidoException();
            }

            return auxiliarDNI;
        }

        /// <summary>
        /// Valida formato Nombre o Apellido
        /// </summary>
        /// <param name="dato">nombre o apellido</param>
        /// <returns>El nombre o apellido, caso contrario null</returns>
        private string ValidarNombreApellido(string dato)
        {
            string retorno = dato;
            for (int i = 0; i < dato.Length; i++)
            {
                if (!Char.IsLetter(dato[i]))
                {
                    retorno = null;
                }
            }
            return retorno;
        }
        #endregion
    }
}
