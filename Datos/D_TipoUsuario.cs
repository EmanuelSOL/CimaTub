using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace Datos
{
    public class D_TipoUsuario : Conexion
    {
        public string BuscarNombreTipoUsuarioPorId(int idTipoUsuario)
        {
            string nombre = string.Empty;

            SqlCommand cmd = new SqlCommand("BuscarNombreTipoUsuarioPorId",connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IdTipoUsuario", idTipoUsuario);

            try
            {
                AbrirConexion();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    nombre = (string)reader["Descripcion"];
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                CerrarConexion();
            }


            return nombre;
        }
    }
}
