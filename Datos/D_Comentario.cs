using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Diagnostics;

namespace Datos
{
    public class D_Comentario : Conexion
    {
        public bool InsertarComentario(E_Comentario comentario)
        {
            SqlCommand cmd = new SqlCommand("Insertar_comentarios", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IdUsuario", comentario.IdUsuario);
            cmd.Parameters.AddWithValue("@IdVideo", comentario.IdVideo);
            cmd.Parameters.AddWithValue("@Contenido", comentario.Contenido);

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

        public List<E_Comentario> ListarComentariosVideo(int idVideo)
        {
            List<E_Comentario> comentarios = new List<E_Comentario>(); 
            SqlCommand cmd = new SqlCommand("ListarComentariosVideo",connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IdVideo", idVideo);

            try
            {
                AbrirConexion();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    E_Comentario comentario = new E_Comentario()
                    {
                        IdComentario = (int)reader["IdComentario"],
                        IdUsuario = (int)reader["IdUsuario"],
                        IdVideo = (int)reader["IdVideo"],
                        Contenido = (string)reader["Contenido"]
                    };

                    comentarios.Add(comentario);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally { CerrarConexion(); }   

            return comentarios;
        }
    }
}
