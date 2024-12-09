using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace Datos
{
    public class D_Video : Conexion
    {
        public bool InsertarVideo(E_Video video)
        {
            SqlCommand cmd = new SqlCommand("Insertar_video", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IdUsuario", video.IdUsuario);
            cmd.Parameters.AddWithValue("@IdCarrera", video.IdCarrera);
            cmd.Parameters.AddWithValue("@IdMateria", video.IdMateria);
            cmd.Parameters.AddWithValue("@Titulo", video.Titulo);
            cmd.Parameters.AddWithValue("@Descripcion", video.Descripcion);
            cmd.Parameters.AddWithValue("@Url", video.Url);
            cmd.Parameters.AddWithValue("@Miniatura", video.Miniatura);
            cmd.Parameters.AddWithValue("@Visibilidad", video.Visibilidad);

            try
            {
                AbrirConexion();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                CerrarConexion();
            }
        }

        public List<E_Video> ListarDestacados()
        {
            List<E_Video> videos = new List<E_Video>();

            SqlCommand cmd = new SqlCommand("Buscar_destacados", connection);
            cmd.CommandType = CommandType.StoredProcedure;

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
                Debug.WriteLine(ex.ToString());
            }
            finally
            {
                CerrarConexion();
            }

            return videos;
        }

        public List<E_Video> FiltrarPorCarrera(int idCarrera)
        {
            List<E_Video> videos = new List<E_Video> ();

            SqlCommand cmd = new SqlCommand("Buscar_video_por_carrera", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IdCarrera", idCarrera);

            try
            {
                AbrirConexion();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    E_Video video = new E_Video()
                    {
                        IdVideo = (int)reader["IdVideo"],
                        Titulo = (string)reader["Titulo"],
                        Descripcion = (string)reader["Descripcion"],
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
                Debug.WriteLine(ex.ToString());
            }
            finally { CerrarConexion(); }

            return videos;
        }

        public List<E_Video> FiltrarPorMateria(int idMateria)
        {
            List<E_Video> videos = new List<E_Video>();

            SqlCommand cmd = new SqlCommand("Buscar_video_por_materia", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IdMateria", idMateria);

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
                Debug.WriteLine(ex.ToString());
            }
            finally { CerrarConexion(); }

            return videos;
        }

        public E_Video BuscarVideoPorId(int idVideo)
        {
            E_Video video = null;
            SqlCommand cmd = new SqlCommand("BuscarVideoPorId", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IdVideo", idVideo);

            try
            {
                AbrirConexion();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    video = new E_Video()
                    {
                        IdVideo = (int)reader["IdVideo"],
                        IdUsuario = (int)reader["IdUsuario"],
                        IdCarrera = (int)reader["IdCarrera"],
                        IdMateria = (int)reader["IdMateria"],
                        Titulo = (string)reader["Titulo"],
                        Descripcion = (string)reader["Descripcion"],
                        Url = (string)reader["Url"],
                        Visitas = (int)reader["Visitas"],
                        Miniatura = (byte[])reader["Miniatura"],
                        Visibilidad = (bool)reader["Visibilidad"]
                    };
                    video.Img = video.getImg();
                    video.Preview = video.getPreView();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            finally
            {
                CerrarConexion();
            }
            return video;
        }

        public bool EditarVideo(E_Video video)
        {
            SqlCommand cmd = new SqlCommand("EditarVideo",connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IdVideo", video.IdVideo);
            cmd.Parameters.AddWithValue("@IdCarrera", video.IdCarrera);
            cmd.Parameters.AddWithValue("@IdMateria", video.IdMateria);
            cmd.Parameters.AddWithValue("@Titulo", video.Titulo);
            cmd.Parameters.AddWithValue("@Descripcion", video.Descripcion);
            cmd.Parameters.AddWithValue("@Miniatura", video.Miniatura);
            cmd.Parameters.AddWithValue("@Visibilidad", video.Visibilidad);

            try
            {
                AbrirConexion();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                CerrarConexion();
            }
        }
    }
}
