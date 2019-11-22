using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class PaqueteDAO
    {
        #region Comandos
        private static SqlCommand comando;
        private static SqlConnection conexion;
        #endregion

        #region Delegado y Evento
        public delegate void MensajeErrorSQL(string m);
        public static event MensajeErrorSQL errorCargaBD;
        #endregion

        #region Métodos

        #region Constructor
        static PaqueteDAO()
        {
            string conexionString = @"Data Source= .\SQLEXPRESS; Initial Catalog= correo-sp-2017; Integrated Security= True";
            //string conexionString = @"Data Source= .\MSSQLSERVER01; Initial Catalog= correo-sp-2017; Integrated Security= True";
            conexion = new SqlConnection(conexionString);
            comando = new SqlCommand();

            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = conexion;
        }
        #endregion

        /// <summary>
        /// Inserta un paquete a la base de datos correo-sp-2017
        /// </summary>
        /// <param name="p"></param>
        /// <returns>true si pudo, caso contrario exception</returns>
        public static bool Insertar(Paquete p)
        {
            bool retorno = false;

            try
            {
                string consultaNonQuery = $"INSERT INTO dbo.Paquetes(direccionEntrega,trackingID,alumno) VALUES('{p.DireccionEntrega}','{p.TrackingID}','Hamie Matias')";

                comando.CommandText = consultaNonQuery;

                conexion.Open();

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                errorCargaBD.Invoke("Problema al grabar informacion en Base de Datos");
            }
            finally
            {
                conexion.Close();
            }

            return retorno;

        }
        #endregion
    }
}
