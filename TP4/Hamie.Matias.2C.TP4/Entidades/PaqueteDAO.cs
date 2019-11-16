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
            string conexionString = @"Data Source=.\SQLEXPRESS; Initial Catalog=correo-sp-2017; Integrated Security=true";
            conexion = new SqlConnection(conexionString);

            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = conexion;
        }
        #endregion

        public static bool Insertar(Paquete p)
        {
            string consultaNonQuery = $"INSERT INTO dbo.Paquetes(alumno,direccionEntrega,trackingID) VALUES('Hamie Matias','{p.DireccionEntrega}','{p.TrackingID}')";

            comando.CommandText = consultaNonQuery;
            conexion.Open();
            
            if (comando.ExecuteNonQuery() == 0)
            {
                throw new Exception("Problema al grabar información en Base de datos");
            }

            return true;
        }
        #endregion
    }
}
