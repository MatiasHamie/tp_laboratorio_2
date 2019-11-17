using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        #region Métodos
        /// <summary>
        /// Método de extensión, Guarda en un archivo ".txt" información de los paquetes
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="archivo"></param>
        /// <returns>true si pudo, caso contrario false</returns>
        public static bool Guardar(this string texto, string archivo)
        {
            if (!string.IsNullOrEmpty(archivo))
            {
                string pathArchivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), archivo);
                StreamWriter writer;

                if (!File.Exists(pathArchivo))
                {
                    writer = new StreamWriter(pathArchivo);
                }
                else
                {
                    writer = new StreamWriter(pathArchivo, true);
                }

                using (writer)
                {
                    writer.WriteLine(texto);
                }

                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
