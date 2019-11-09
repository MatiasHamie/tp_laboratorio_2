using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Xml<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            bool retorno = false;
            try
            {
                string pathArchivoEnEscritorio = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), archivo);

                XmlTextWriter xmlTextWriter = new XmlTextWriter(pathArchivoEnEscritorio, System.Text.Encoding.UTF8);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

                xmlSerializer.Serialize(xmlTextWriter, datos);
                xmlTextWriter.Close();
                retorno = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return retorno;
        }

        public bool Leer(string archivo, out T datos)
        {
            bool retorno = false;

            try
            {
                string pathArchivoEnEscritorio = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), archivo);
                
                XmlTextReader xmlTextReader = new XmlTextReader(pathArchivoEnEscritorio);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

                datos = (T)xmlSerializer.Deserialize(xmlTextReader);
                xmlTextReader.Close();
                retorno = true;
            }
            catch (Exception e)
            {
                datos = default(T);//Asigno default de un string = null
                throw new ArchivosException(e);
            }

            return retorno;
        }
    }
}
