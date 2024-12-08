using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace Datos
{
    public class D_Alumno : Conexion
    {
        public bool InsertarAlumno(E_Alumno alumno)
        {
            SqlCommand cmd = new SqlCommand("Registrar_alumno",connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IdUsuario", alumno.IdUsuario);
            cmd.Parameters.AddWithValue("@IdCarrera", alumno.IdCarrera);

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
