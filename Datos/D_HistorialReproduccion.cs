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

        public List<E_Video> ListarVideosHistorial(int idUsuario)
        {
            List<E_Video> videos = new List<E_Video>();
            SqlCommand cmd = new SqlCommand("ListarVideosHistorial", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

            try
            {
                AbrirConexion();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    E_Video video = new E_Video()
                    {
                        IdVideo = (int)reader["IdVideo"],
                        Titulo = (string)reader["Titulo"],
                        Descripcion = (string)reader["Descripcion"],
                        Visitas = (int)reader["Visitas"],
                        Miniatura = (byte[])reader["Miniatura"],
                        Url = (string)reader["Url"],
                    };
                    video.Img = video.getImg();
                    video.Preview = video.getPreView();
                    videos.Add(video);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                CerrarConexion();
            }
            return videos;
        }
    }
}
