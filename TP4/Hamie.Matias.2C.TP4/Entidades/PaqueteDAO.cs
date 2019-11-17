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
                throw new Exception("Problema al grabar información en Base de datos");
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
