using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;


namespace Datos
{
    public class Conexion
    {
        protected SqlConnection connection;

        public Conexion()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        }

        protected void AbrirConexion()
        {
            try
            {
                if (connection.State == ConnectionState.Closed || connection.State == ConnectionState.Broken)
                    connection.Open();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al conectar: " + ex.Message);
            }
        }

        protected void CerrarConexion() {
            try
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            catch (Exception ex) { 
                Debug.WriteLine("Error al cerrar conexion"+ex.Message); 
            }
        }
    }
}
