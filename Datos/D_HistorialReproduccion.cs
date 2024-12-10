using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class D_HistorialReproduccion : Conexion
    {
        public bool InsertarHistorialReproduccion(E_HistorialReproduccion historial)
        {
            SqlCommand cmd = new SqlCommand("InsertarHistorialReproduccion",connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IdUsuario", historial.IdUsuario);
            cmd.Parameters.AddWithValue("@IdVideo", historial.IdVideo);

            Debug.WriteLine(historial.IdUsuario);
            Debug.WriteLine(historial.IdVideo);

            try
            {
                AbrirConexion();
                cmd.ExecuteNonQuery();
                
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
            finally
            {
                CerrarConexion();
            }
        }
    }
}
