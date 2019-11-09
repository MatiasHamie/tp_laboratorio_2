using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        public bool Guardar(string archivo, string datos)
        {
            bool retorno = false;
            try
            {
                string pathArchivoEnEscritorio = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), archivo);

                StreamWriter streamWriter = new StreamWriter(pathArchivoEnEscritorio);
                streamWriter.WriteLine(datos);
                streamWriter.Close();
                retorno = true;
            }
            catch (Exception exc)
            {
                throw new ArchivosException(exc);
            }

            return retorno;
        }

        public bool Leer(string archivo, out string datos)
        {
            bool retorno = false;

            try
            {
                string pathArchivoEnEscritorio = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), archivo);

                StreamReader streamReader = new StreamReader(pathArchivoEnEscritorio);
                datos = streamReader.ReadToEnd();
                streamReader.Close();

                retorno = true;
            }
            catch (Exception exc)
            {
                datos = default(string);
                throw new ArchivosException(exc);
            }

            return retorno;
        }
    }
}
