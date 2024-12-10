using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Diagnostics;
using Entidades;

namespace Datos
{
    public class D_Reaccion : Conexion
    {
        public bool InsertarReaccion(E_Reaccion reaccion)
        {
            SqlCommand cmd = new SqlCommand("InsertarReaccion", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IdVideo", reaccion.IdVideo);
            cmd.Parameters.AddWithValue("@IdUsuario", reaccion.IdUsuario);
            cmd.Parameters.AddWithValue("@IdTipoReaccion", reaccion.IdTipoReaccion);

            try
            {
                AbrirConexion();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                CerrarConexion();
            }

        }

        public string BuscarReaccionDeUsuario(E_Reaccion reaccion)
        {
            string tipo = string.Empty;
            SqlCommand cmd = new SqlCommand("BuscarReaccionDeUsuario", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IdVideo", reaccion.IdVideo);
            cmd.Parameters.AddWithValue("@IdUsuario", reaccion.IdUsuario);

            try
            {
                AbrirConexion();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    tipo = (string)reader["Descripcion"];
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

            return tipo;
        }

        public int ContarLikes(int idVideo)
        {
            int likes = 0;
            SqlCommand cmd = new SqlCommand("ContarLikes", connection);
            cmd.CommandType=CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IdVideo", idVideo);

            try
            {
                AbrirConexion();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    likes =(int)reader["likes"];
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

            return likes;
        }

        public int ContarDislikes(int idVideo)
        {
            int dislikes = 0;
            SqlCommand cmd = new SqlCommand("ContarDislikes", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IdVideo", idVideo);

            try
            {
                AbrirConexion();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    dislikes = (int)reader["dislikes"];
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

            return dislikes;
        }
    }
}
